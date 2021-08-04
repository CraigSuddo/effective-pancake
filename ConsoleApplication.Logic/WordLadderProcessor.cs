using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication.Logic
{
    /// <summary>
    /// Solves the Word Ladder puzzle.
    /// </summary>
    public class WordLadderProcessor : IWordLadderProcessor
    {
        #region Dependency Injected Properties
        private IWordLadderProcessorConfiguration _config { get; set; }
        private IWordLadderProcessorOutput _output { get; set; }
        #endregion

        #region Standard OOP Properties 
        private IWordLadderProcessorResult Result { get; set; }
        private HashSet<Dictionary<int, Word>> Solutions { get; set; }
        private HashSet<Word> Words { get; set; }
        private int SearchDepth { get; set; }
        #endregion

        public WordLadderProcessor(IWordLadderProcessorConfiguration config, IWordLadderProcessorOutput output)
        {
            // Dependency injections
            _config = config;
            _output = output;

            // Object instantiations
            Result = new WordLadderProcessorResult();
            Words = new HashSet<Word>();
            Solutions = new HashSet<Dictionary<int, Word>>();
        }

        /// <summary>
        /// Handles which methods get called to process the system. This is the main spine of the application.
        /// </summary>
        /// <returns>The result object which has completed.</returns>
        public IWordLadderProcessorResult Process()
        {
            SetupWords();
            SolutionSearch();
            GenerateResult();
            return Result;
        }

        /// <summary>
        /// The main block of the class, starts the initial search from the StartWord then progresses through the CheckForSolution.
        /// </summary>
        private void SolutionSearch()
        {
            // Find all the potential solutions. - This is very slow, some are over 1000 steps long.
            var start = Words.FirstOrDefault(w => w.Value == _config.StartWord.ToUpperInvariant());
            do
            {
                SearchDepth++;
                CheckForSolution(start, new List<Word>() { start }, SearchDepth);
            }
            while (Solutions.Count == 0  && SearchDepth < Words.Count); // Without an upper limit I found one with 1170 steps... that took a while!
                                                                        // You cannot have a search depth beyond all of the words, if you have something has gone wrong!
        }

        /// <summary>
        /// Sets up each Word object to link it to other words which are one step away.
        /// </summary>
        private void SetupWords()
        {
            // Find only X letter words, clean down the list so we are only processing using 4 letter words which will reduce memory usage.
            _config.Words = _config.Words.Where(w => w.Trim().Length == _config.WordLength)
                                         .ToList();

            // Create the Word objects.
            _config.Words.ForEach(w => Words.Add(new Word(w)));

            // Connect the Word objects.
            foreach (var word in Words)
            {
                foreach (var template in word.Templates)
                {
                    var matchingTemplateWords = Words.Where(w => w.Value != word.Value)
                                                     .Where(w => w.Templates.Contains(template))
                                                     .ToList();

                    word.ConnectedWords.AddRange(matchingTemplateWords);
                }
            }
        }

        /// <summary>
        /// Calls the injected output class after determining whether it has been a successful search or not.
        /// </summary>
        private void GenerateResult()
        {
            // Return the solution(s) with the least steps - I anticipate that occasionally there may be more than 1 solution from Start - End
            var shortestSolution = Solutions.OrderBy(s => s.Count).FirstOrDefault();

            if (shortestSolution == null)
                _output.Unsuccessful(Result);
            else
            {
                Result.Steps = shortestSolution.Select(ss => new { ss.Key, ss.Value.Value })
                                               .ToDictionary(d => d.Key, d => d.Value);
                Result.Successful = true;
                _output.Successful(Result);
            }
        }
        /// <summary>
        /// The main method used for finding solutions. This method is nested so that it can search down the potential word chain and then back up again.
        /// </summary>
        /// <param name="word">The Word which is being searched.</param>
        /// <param name="currentChain">The current progress along the chain, this is to prevent going back into words that the chain already contains and ending up in infinite loops.</param>
        /// <param name="searchDepth">The current limit to search to. Ensures that the program tries to find the shortest solutions first.</param>
        private void CheckForSolution(Word word, List<Word> currentChain, int searchDepth)
        {
            foreach (var connectedWord in word.ConnectedWords.Where(cw => !currentChain.Select(cc => cc.Value).Contains(cw.Value)))
            {
                currentChain.Add(connectedWord);
                if (connectedWord.Value == _config.EndWord.ToUpperInvariant())
                {
                    // Solution found!
                    AddSolution(currentChain);
                }
                else
                {
                    if (currentChain.Count < searchDepth)
                        CheckForSolution(connectedWord, currentChain, searchDepth);
                }

                // Remove from chain
                currentChain.Remove(connectedWord);
            }
        }

        /// <summary>
        /// Add the current chain to the Solutions set.
        /// </summary>
        /// <param name="currentChain">The current chain which represents the searches current position.</param>
        private void AddSolution(List<Word> currentChain)
        {
            var dictionary = currentChain.Select((c, i) => new { Value = c, Index = i })
                                         .ToDictionary(d => d.Index, d => d.Value);
            Solutions.Add(dictionary);
        }
    }
}

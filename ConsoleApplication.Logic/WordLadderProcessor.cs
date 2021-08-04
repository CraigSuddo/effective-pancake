using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication.Logic
{
    public class WordLadderProcessor : IWordLadderProcessor
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        private IWordLadderProcessorOutput _output { get; set; }

        public IWordLadderProcessorResult Result { get; set; }
        private HashSet<Dictionary<int, Word>> Solutions { get; set; }
        private HashSet<Word> Words { get; set; }
        private int SearchDepth { get; set; }

        public WordLadderProcessor(IWordLadderProcessorConfiguration config, IWordLadderProcessorOutput output)
        {
            _config = config;
            Result = new WordLadderProcessorResult();
            Words = new HashSet<Word>();
            Solutions = new HashSet<Dictionary<int, Word>>();
            _output = output;
        }

        public IWordLadderProcessorResult Process()
        {
            SetupWords();
            SolutionSearch();
            GenerateResult();
            return Result;
        }

        private void SolutionSearch()
        {
            // Find all the potential solutions. - This is very slow, some are over 1000 steps long.
            var start = Words.FirstOrDefault(w => w.Value == _config.StartWord);
            do
            {
                SearchDepth++;
                CheckForSolution(start, new List<Word>() { start }, SearchDepth);
            }
            while (Solutions.Count == 0  && SearchDepth < 1000); // Without an upper limit I found 1170 steps... that took a while!
        }

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

        private void CheckForSolution(Word word, List<Word> currentChain, int searchDepth)
        {
            foreach (var connectedWord in word.ConnectedWords.Where(cw => !currentChain.Select(cc => cc.Value).Contains(cw.Value)))
            {
                currentChain.Add(connectedWord);
                if (connectedWord.Value.ToUpperInvariant() == _config.EndWord.ToUpperInvariant())
                {
                    // Solution found!
                    AddSolution(currentChain);
                }
                else
                {
                    // bump the depth if chars match
                    var additionalDepth = GetAdditionalDepth(connectedWord.Value, _config.EndWord);

                    if (currentChain.Count < searchDepth)
                        CheckForSolution(connectedWord, currentChain, searchDepth);
                }

                // Remove from chain
                currentChain.Remove(connectedWord);
            }
        }

        private int GetAdditionalDepth(string value, string endWord)
        {
            var result = 0;
            var upperValue = value.ToUpperInvariant();
            var upperEndWord = endWord.ToUpperInvariant();

            for (var i =0; i<value.Length;i++)
            {
                if (upperValue[i] == upperEndWord[i])
                    result++;
            }
            return result;
        }

        private void AddSolution(List<Word> currentChain)
        {
            var dictionary = currentChain.Select((c, i) => new { Value = c, Index = i })
                                         .ToDictionary(d => d.Index, d => d.Value);
            Solutions.Add(dictionary);
        }
    }
}

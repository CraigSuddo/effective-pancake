using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication.Logic
{
    public class WordLadderProcessor : IWordLadderProcessor
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        public IWordLadderProcessorResult Result { get; set; }

        private List<Dictionary<int,Word>> Solutions { get; set; }

        private List<Word> Words { get; set; }

        public WordLadderProcessor(IWordLadderProcessorConfiguration config)
        {
            _config = config;
            Result = new WordLadderProcessorResult();
            Words = new List<Word>();
            Solutions = new List<Dictionary<int, Word>>();
        }

        public IWordLadderProcessorResult Process()
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

            // Find all the potential solutions.
            var start = Words.FirstOrDefault(w => w.Value == _config.StartWord);
            CheckForSolution(start, new List<Word>() { start });

            // Return the solution(s) with the least steps - I anticipate that occasionally there may be more than 1 solution from Start - End
            var shortestSolution = Solutions.OrderBy(s => s.Count).FirstOrDefault();

            if (shortestSolution == null)
            {

                Console.WriteLine("No solutions found!");
                Result.Successful = false;
            }
            else
            {
                Result.Steps = shortestSolution.Select(ss => new { ss.Key, ss.Value.Value })
                                               .ToDictionary(d => d.Key, d => d.Value);

                File.WriteAllLines(_config.ResultFile, Result.Steps.Select(s => s.Value).ToArray());
                Result.OutputFile = _config.ResultFile;
            }

            return Result;
        }

        private void CheckForSolution(Word word, List<Word> currentChain)
        {
            foreach (var connectedWord in word.ConnectedWords.Where(cw => !currentChain.Select(cc => cc.Value).Contains(cw.Value)))
            {
                Console.WriteLine($"Adding {connectedWord.Value} to chain.");
                currentChain.Add(connectedWord);
                if (connectedWord.Value == _config.EndWord)
                {
                    // Solution found!
                    AddSolution(currentChain);
                }
                else
                {
                    CheckForSolution(connectedWord, currentChain);
                }
                // Remove from chain
                Console.WriteLine($"Removing {connectedWord.Value} from chain.");
                currentChain.Remove(connectedWord);
            }
        }

        private void AddSolution(List<Word> currentChain)
        {
            var dictionary = currentChain.Select((c, i) => new { Value = c, Index = i })
                                         .ToDictionary(d => d.Index, d => d.Value);
            Solutions.Add(dictionary);
        }
    }
}

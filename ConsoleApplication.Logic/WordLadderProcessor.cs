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

        private List<Dictionary<int, string>> Solutions { get; set; }

        private List<Word> Words { get; set; }

        public WordLadderProcessor(IWordLadderProcessorConfiguration config)
        {
            _config = config;
            Result = new WordLadderProcessorResult();
            Words = new List<Word>();
        }

        public IWordLadderProcessorResult Process()
        {
            try
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

                        word.ConnectedWords = matchingTemplateWords;                 
                    }    
                }

                // Find all the potential solutions.

                // Trying something new - the solution is to make word chains, so instead what I'll do is work every potential chain through from start to a dead end.
                var start = Words.FirstOrDefault(w => w.Value == _config.StartWord);
                CheckForSolution(start, null);



                // Return the solution(s) with the least steps - I anticipate that occasionally there may be more than 1 solution from Start - End


            }
            catch (Exception e)
            {

            }

            return Result;
        }


        //TODO: Something is really wrong with my logic. I'm finding connected words, but not really progressing through the tree I have.
        // Also if a connected word has multiple connections, then I could end up going down the same routes over and over.
        // When I find a dead end, I could add these to a list of dead ends so that I avoid them in future.
        private void CheckForSolution(Word word, Word parent)
        {
            var parentValue = parent == null ? string.Empty : parent.Value;
            foreach (var connectedWord in word.ConnectedWords.Where(cw => cw.Value != parentValue))
            {
                if (connectedWord.Value == _config.EndWord)
                {
                    // Solution found!
                    return;
                }
                else
                {
                    CheckForSolution(connectedWord, parent);
                }
            }
        }

        private void AddSolution(List<string> ancestors)
        {
            var dict = new Dictionary<int, string>();
            for (var i = 0; i< ancestors.Count; i++)
            {
                dict.Add(i, ancestors[i]);
            }

            Solutions.Add(dict);
        }
    }
}

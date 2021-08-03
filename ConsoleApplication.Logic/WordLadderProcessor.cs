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
                        var matchingTemplateWord = Words.Where(w => w.Value != word.Value)
                                                        .Where(w => w.Templates.Contains(template))
                                                        .ToList();

                        word.ConnectedWords = matchingTemplateWord;                        
                    }    
                }

                // Find all the potential solutions.


                // Return the solution(s) with the least steps - I anticipate that occasionally there may be more than 1 solution from Start - End


            }
            catch (Exception e)
            {

            }

            return Result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication.Logic
{
    public class WordLadderProcessor : IWordLadderProcessor
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        public IWordLadderProcessorResult Result { get; set; }

        private List<string> Words { get; set; }

        public WordLadderProcessor(IWordLadderProcessorConfiguration config)
        {
            _config = config;
            Result = new WordLadderProcessorResult();
        }

        public IWordLadderProcessorResult Process()
        {
            try
            {
                // Read in the file
                ReadFile();

                // Find only four letter words, clean down the list so we are only processing using 4 letter words which will reduce memory usage.

                // 
            }
            catch (Exception e)
            {

            }

            return Result;
        }

        private void ReadFile()
        {
            // Get the lines
            var lines = File.ReadAllLines(_config.DictionaryFile);

            // Clean and then parse anything which is 4 letters into the Words list.
            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (trimmed.Length == 4)
                    Words.Add(trimmed.ToUpperInvariant());


            }
            
        }
    }
}

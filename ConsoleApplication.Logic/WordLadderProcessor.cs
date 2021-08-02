using System;

namespace ConsoleApplication.Logic
{
    public class WordLadderProcessor : IWordLadderProcessor
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        public IWordLadderProcessorResult Result { get; set; }

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

                // Find only four letter words, clean down the list so we are only processing using 4 letter words which will reduce memory usage.

                // 
            }
            catch (Exception e)
            {

            }

            return Result;
        }

    }
}

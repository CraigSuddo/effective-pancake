using CommandLine;
using ConsoleApplication.Logic;
using System.Collections.Generic;

namespace ConsoleApplication.Classes
{
    class CommandLineOptions : IWordLadderProcessorConfiguration
    {
        [Option(Default = "words-english.txt", HelpText = "The input file of words to be used with this software.", Required = true)]
        public string DictionaryFile { get; set; }
        [Option(Default = "Spin", HelpText = "The word to begin the puzzle from.", Required = true)]
        public string StartWord { get; set; }
        [Option(Default = "Spot", HelpText = "The word to finish the puzzle at.", Required = true)]
        public string EndWord { get; set; }
        [Option(Default = "output.txt", HelpText = "The output file of words to show the solution.", Required = true)]
        public string ResultFile { get; set; }

        public List<string> Words { get; set; }
        public int WordLength { get; set; }

        public CommandLineOptions()
        {
            WordLength = 4;
        }
    }
}
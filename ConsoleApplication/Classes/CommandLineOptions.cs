using CommandLine;
using ConsoleApplication.Logic;
using System.Collections.Generic;

namespace ConsoleApplication.Classes
{
     /// <summary>
     /// The command line options which can be provided to the system.
     /// </summary>
    class CommandLineOptions : IWordLadderProcessorConfiguration
    {
        /// <summary>
        /// The filename which contains the dictionary to use.
        /// </summary>
        [Option(Default = "words-english.txt", HelpText = "The input file of words to be used with this software.", Required = true)]
        public string DictionaryFile { get; set; }
        /// <summary>
        /// The word to start from.
        /// </summary>
        [Option(Default = "Spin", HelpText = "The word to begin the puzzle from.", Required = true)]
        public string StartWord { get; set; }
        /// <summary>
        /// The end word to process to.
        /// </summary>
        [Option(Default = "Spot", HelpText = "The word to finish the puzzle at.", Required = true)]
        public string EndWord { get; set; }
        /// <summary>
        /// The file to be output. This will be moved in the future to a file-writing specific options file.
        /// </summary>
        [Option(Default = "output.txt", HelpText = "The output file of words to show the solution.", Required = true)]
        public string ResultFile { get; set; }
        /// <summary>
        /// The words which we are going to use once they have been read in.
        /// </summary>
        public List<string> Words { get; set; }
        /// <summary>
        /// Included so that in the future I can look at adding the potential to solve longer words.
        /// </summary>
        public int WordLength { get; set; }

        public CommandLineOptions()
        {
            WordLength = 4;
        }
    }
}
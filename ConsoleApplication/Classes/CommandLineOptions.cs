using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Classes
{
    class CommandLineOptions
    {
        [Option(Default = "words-english.txt", HelpText = "The input file of words to be used with this software.", Required = true)]
        public string DictionaryFile { get; set; }
        [Option(Default = "Spin", HelpText = "The word to begin the puzzle from.", Required = true)]
        public string StartWord { get; set; }
        [Option(Default = "Spot", HelpText = "The word to finish the puzzle at.", Required = true)]
        public string EndWord { get; set; }
        [Option(Default = "output.txt", HelpText = "The output file of words to show the solution.", Required = true)]
        public string ResultFile { get; set; }
    }
}

//DictionaryFile - the file name of a text file containing four letter words(included in the test pack)
//StartWord - a four letter word(that you can assume is found in the DictionaryFile file)
//EndWord - a four letter word(that you can assume is found in the DictionaryFile file)
//ResultFile - the file name of a text file that will contain the result
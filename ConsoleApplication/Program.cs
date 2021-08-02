using CommandLine;
using ConsoleApplication.Classes;
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Process the args
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                   .WithParsed(o =>
                   {
                       if (!ValidateOptions(o))
                       {
                           Console.WriteLine("Unable to process the requested information.");
                           return;
                       }

                       // Read Dictionary file in the most performant way; it has a lot of lines.


                       // Find four letter words only


                       // Clear out of memory anything which is not a four letter word.



                   });


        }

        /// <summary>
        /// Ensure that the configuration provided is valid.
        /// </summary>
        /// <param name="o">Options provided to the software.</param>
        /// <returns>A bool result indicating whether the file is valid or not.</returns>
        private static bool ValidateOptions(CommandLineOptions o)
        {
            var hasErrors = false;
            if (o.StartWord.Length != 4)
            {
                Console.WriteLine("Start Word is not 4 letters long.");
                hasErrors = true;
            }

            if (o.EndWord.Length != 4)
            {
                Console.WriteLine("End Word is not 4 letters long.");
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(o.DictionaryFile) || !File.Exists(o.DictionaryFile))
            {

                Console.WriteLine("Dictionary File not found.");
                hasErrors = true;
            }

            if (string.IsNullOrEmpty(o.ResultFile) || File.Exists(o.ResultFile))
            {

                Console.WriteLine("Result File not provided or already exists.");
                hasErrors = true;
            }

            return hasErrors;
        }
    }
}

//Your program should calculate the shortest list of four letter words, starting with StartWord, and ending with EndWord, with a number of intermediate words that must appear in the DictionaryFile file where each word differs from the previous word by one letter only.The result should be written to the destination specified by the ResultFile argument.

//For example, if StartWord = Spin, EndWord = Spot and DictionaryFile file contains
//Spin
//Spit
//Spat
//Spot
//Span

//then ResultFile should contain
//Spin
//Spit
//Spot

//Two examples of incorrect results:
//Spin, Span, Spat, Spot(incorrect as it takes 3 changes rather than 2)
//Spin, Spon, Spot(incorrect as spon is not a word)

//Your solution should deal with the case where the dictionary file is not in alphabetical order.

//Please explain the thought/development process you went through to achieve your solution.Your solution should be both elegant and maintainable.  Extra points awarded for solutions that have an emphasis on how the code will be tested, and performance implications.


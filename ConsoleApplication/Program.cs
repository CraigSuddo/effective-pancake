using CommandLine;
using ConsoleApplication.Classes;
using ConsoleApplication.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run the initial start up configuration, moved to a static class to ensure entry point of Application is clean.
            Startup.Configure(args);




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


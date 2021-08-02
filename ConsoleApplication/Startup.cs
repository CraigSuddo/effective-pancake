using CommandLine;
using ConsoleApplication.Classes;
using ConsoleApplication.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApplication
{
    internal static class Startup
    {
        /// <summary>
        /// Configures the application using the provided arguments, and sets this application up as a Console application.
        /// </summary>
        /// <param name="args">The console paramaters provided to the application.</param>
        internal static void Configure(string[] args)
        {
            // Set up the DI Service.
            var provider = new ServiceCollection();

            // Process the args
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                   .WithParsed(o =>
                   {
                       if (!ValidateOptions(o))
                       {
                           Console.WriteLine("Unable to process the requested information.");
                           return;
                       }

                       // Add the configuration to DI.
                       provider.AddSingleton<IWordLadderProcessorConfiguration>(o);
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

using CommandLine;
using ConsoleApplication.Classes;
using ConsoleApplication.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    internal static class Startup
    {
        /// <summary>
        /// Configures the application using the provided arguments, and sets this application up as a Console application.
        /// </summary>
        /// <param name="args">The console paramaters provided to the application.</param>
        internal static IHostBuilder Configure(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);
            // Process the args
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                   .WithParsed(o =>
                   {
                       if (!ValidateOptions(o))
                       {
                           Console.WriteLine("Unable to process the requested information.");
                           return;
                       }

                       o.Words = File.ReadAllLines(o.DictionaryFile).ToList();

                       host.ConfigureServices((_, services) =>
                           {
                               services.AddSingleton<IWordLadderProcessorConfiguration>(o);
                               services.AddTransient<IWordLadderProcessorOutput, ConsoleApplicationWordLadderProcessorOutput>();
                               services.AddTransient<IWordLadderProcessor, WordLadderProcessor>();
                           });
                   });

            return host;
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

            if (string.IsNullOrEmpty(o.ResultFile))
            {

                Console.WriteLine("Result File not provided or already exists.");
                hasErrors = true;
            }

            return !hasErrors;
        }
    }
}

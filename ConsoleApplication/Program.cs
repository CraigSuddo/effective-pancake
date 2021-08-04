using CommandLine;
using ConsoleApplication.Classes;
using ConsoleApplication.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run the initial start up configuration, moved to a static class to ensure entry point of Application is clean.
            using (var host = Startup.Configure(args).Build())
            {
                // Create a Processor.
                var processor = host.Services.GetService<IWordLadderProcessor>();

                // Run it and get the result.
                var result = processor.Process();
                if (result.Successful)
                    Console.WriteLine($"Shortest possible result is: {string.Join(",", result.Steps)}");
                else
                    Console.WriteLine($"Depth is too great!");
            }
        }
    }
}
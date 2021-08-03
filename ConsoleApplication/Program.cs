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
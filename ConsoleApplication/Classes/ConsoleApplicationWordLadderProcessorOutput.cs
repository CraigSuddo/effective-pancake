using ConsoleApplication.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Classes
{
    /// <summary>
    /// The console application output class. This defines how the console application would like a success or failure to be handled.
    /// </summary>
    internal class ConsoleApplicationWordLadderProcessorOutput : IWordLadderProcessorOutput
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public ConsoleApplicationWordLadderProcessorOutput(IWordLadderProcessorConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Successful method for processing what to do with a successful result.
        /// </summary>
        /// <param name="result">The result object which is defined on the word processor logic.</param>
        public void Successful(IWordLadderProcessorResult result)
        {
            // Write out to file the successful result
            if (File.Exists(_config.ResultFile))
                File.Delete(_config.ResultFile);

            File.WriteAllLines(_config.ResultFile, result.Steps.Select(s => s.Value).ToArray());
            result.OutputFile = _config.ResultFile;
            result.Successful = true;
        }

        /// <summary>
        /// Unsuccessful method for processing an unsuccessful result.
        /// </summary>
        /// <param name="result">The result object being defined on the word processor logic.</param>
        public void Unsuccessful(IWordLadderProcessorResult result)
        {
            // Error output

        }
    }
}

using ConsoleApplication.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Classes
{
    internal class ConsoleApplicationWordLadderProcessorOutput : IWordLadderProcessorOutput
    {
        private IWordLadderProcessorConfiguration _config { get; set; }
        public ConsoleApplicationWordLadderProcessorOutput(IWordLadderProcessorConfiguration config)
        {
            _config = config;
        }

        public void Successful(IWordLadderProcessorResult result)
        {
            // Write out to file the successful result
            if (File.Exists(_config.ResultFile))
                File.Delete(_config.ResultFile);

            File.WriteAllLines(_config.ResultFile, result.Steps.Select(s => s.Value).ToArray());
            result.OutputFile = _config.ResultFile;
            result.Successful = true;
        }

        public void Unsuccessful(IWordLadderProcessorResult result)
        {
            // Error output

        }
    }
}

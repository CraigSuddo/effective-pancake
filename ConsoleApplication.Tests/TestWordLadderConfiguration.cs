using ConsoleApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Tests
{
    /// <summary>
    /// This class is provided as an implementation of the configuration specifically for tests.
    /// </summary>
    internal class TestWordLadderConfiguration : IWordLadderProcessorConfiguration
    {
        public List<string> Words { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string ResultFile { get; set; }
        public int WordLength { get; set; }
    }
}

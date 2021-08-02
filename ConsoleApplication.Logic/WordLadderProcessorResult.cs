using System.Collections.Generic;

namespace ConsoleApplication.Logic
{
    internal class WordLadderProcessorResult : IWordLadderProcessorResult
    {
        public bool Successful { get; set; }
        public string OutputFile { get; set; }
        public Dictionary<int, string> Steps { get; set; }
    }
}
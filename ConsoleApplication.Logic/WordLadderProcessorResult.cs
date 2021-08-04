using System.Collections.Generic;

namespace ConsoleApplication.Logic
{
    /// <summary>
    /// The result from the Processor.
    /// </summary>
    internal class WordLadderProcessorResult : IWordLadderProcessorResult
    {
        /// <summary>
        /// Whether the process has succeeded.
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// The file which has been output. This needs moving to a File-Writing specific output class, potentially in a future version.
        /// </summary>
        public string OutputFile { get; set; }
        /// <summary>
        /// The successful steps to go from Start -> End
        /// </summary>
        public Dictionary<int, string> Steps { get; set; }
    }
}
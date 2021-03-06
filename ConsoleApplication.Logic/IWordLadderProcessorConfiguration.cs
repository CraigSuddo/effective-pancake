using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Logic
{
    public interface IWordLadderProcessorConfiguration
    {
        public List<string> Words { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string ResultFile { get; set; }

        public int WordLength { get; set; }
    }
}

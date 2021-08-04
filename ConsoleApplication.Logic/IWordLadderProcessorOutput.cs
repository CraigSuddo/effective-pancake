using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Logic
{
    public interface IWordLadderProcessorOutput
    {
        public void Successful(IWordLadderProcessorResult result);
        public void Unsuccessful(IWordLadderProcessorResult result);
    }
}

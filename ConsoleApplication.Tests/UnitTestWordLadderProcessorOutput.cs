using ConsoleApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Tests
{
    public class UnitTestWordLadderProcessorOutput : IWordLadderProcessorOutput
    {
        public void Successful(IWordLadderProcessorResult result)
        {
            result.Successful = true;
        }

        public void Unsuccessful(IWordLadderProcessorResult result)
        {
            result.Successful = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Logic
{
    internal class Word
    {
        private string Value { get; set; }
        private List<string> PotentialMatches { get; set; }

        public Word(string value)
        {
            Value = value;
            SetupPotentialMatches();
        }

        private void SetupPotentialMatches()
        {
            PotentialMatches = new List<string>();

            // Replace each character with an underscore to give a list of potential generic matches.
            // For example; spin would be _pin, s_in, sp_n and spi_. This gives me something to join words together with.

            for (var i = 0; i < Value.Length; i++)
            {
                var characters = Value.ToCharArray();
                characters[i] = '_';
                PotentialMatches.Add(string.Join("", characters));
            }
        }
    }
}

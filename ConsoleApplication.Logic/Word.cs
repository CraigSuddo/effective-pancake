using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Logic
{
    internal class Word
    {
        /// <summary>
        /// The string that the Word object represents, i.e. "Spot"
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The templates which the Word is going to use for finding relations; _pot, S_ot, sp_t, spo_
        /// </summary>
        public List<string> Templates { get; set; }

        /// <summary>
        /// Any words which share a common template, works in the same way they would be SQL joined.
        /// </summary>
        public List<Word> ConnectedWords { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The string value this Word will hold.</param>
        public Word(string value)
        {
            Value = value.ToUpperInvariant();
            SetupTemplates();
            ConnectedWords = new List<Word>();
        }
        /// <summary>
        /// Creates the joining templates so that when querying you can join elements together based on their templates. This creates routes between nodes.
        /// As this is a relatively small task I feel it is fine to be a part of the Constructor.
        /// </summary>
        private void SetupTemplates()
        {
            Templates = new List<string>();
            // Replace each character with an underscore to give a list of potential generic matches.
            // For example; spin would be _pin, s_in, sp_n and spi_. This gives me something to join words together with.

            for (var i = 0; i < Value.Length; i++)
            {
                var characters = Value.ToCharArray();
                characters[i] = '_';
                Templates.Add(string.Join("", characters).ToUpperInvariant());
            }
        }
    }
}

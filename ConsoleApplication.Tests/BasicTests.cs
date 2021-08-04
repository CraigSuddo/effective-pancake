using ConsoleApplication.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void InitialTest()
        {
            // This tests purpose is just to check that the solution works to begin with.
            // Arrange
            var config = new TestWordLadderConfiguration
            {
                EndWord = "Spot",
                StartWord = "Spin",
                Words = new List<string> { "Spin", "Spit", "Spat", "Spot", "Span", },
                WordLength = 4,
                ResultFile = "test.txt"
            };

            var expectedResult = new Dictionary<int, string>
            {
                { 0, "SPIN" },
                { 1, "SPIT" },
                { 2, "SPOT" }
            };

            var output = new UnitTestWordLadderProcessorOutput();

            // Act
            var processor = new WordLadderProcessor(config, output);
            var result = processor.Process();

            // Assert
            Assert.AreEqual(string.Join(",",expectedResult), string.Join(",", result.Steps));
        }

        [TestMethod]
        public void EnhancedTest1()
        {
            // This tests purpose is just to check that the solution works to begin with.
            // Arrange
            var config = new TestWordLadderConfiguration
            {
                EndWord = "Spot",
                StartWord = "Spin",
                Words = GetFullWords(),
                WordLength = 4,
                ResultFile = "test.txt"
            };

            var expectedResult = new Dictionary<int, string>
            {
                { 0, "SPIN" },
                { 1, "SPIT" },
                { 2, "SPOT" }
            };

            var output = new UnitTestWordLadderProcessorOutput();

            // Act
            var processor = new WordLadderProcessor(config, output);
            var result = processor.Process();

            // Assert
            Assert.AreEqual(string.Join(",", expectedResult), string.Join(",", result.Steps));
        }

        [TestMethod]
        public void EnhancedTest2()
        {
            // This tests purpose is just to check that the solution works to begin with.
            // Arrange
            var config = new TestWordLadderConfiguration
            {
                EndWord = "Mach",
                StartWord = "kick",
                Words = GetFullWords(),
                WordLength = 4,
                ResultFile = "test.txt"
            };

            var expectedResult = new Dictionary<int, string>
            {
                { 0, "KICK" },
                { 1, "HICK" },
                { 2, "HACK" },
                { 3, "MACK" },
                { 4, "MACH" }
            };

            var output = new UnitTestWordLadderProcessorOutput();

            // Act
            var processor = new WordLadderProcessor(config, output);
            var result = processor.Process();

            // Assert
            Assert.AreEqual(string.Join(",", expectedResult), string.Join(",", result.Steps));
        }

        private List<string> GetFullWords()
        {
            var lines = File.ReadAllLines("words-english.txt");
            return lines.Select(l => l).ToList();
        }

    }
}

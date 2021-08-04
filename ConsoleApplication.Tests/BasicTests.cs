using ConsoleApplication.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleApplication.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void InitialTest()
        {
            // The processor needs some work before it can be tested better.

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
                { 0, "Spin" },
                { 1, "Spit" },
                { 2, "Spot" }
            };

            // Act
            var processor = new WordLadderProcessor(config);
            var result = processor.Process();

            // Assert
            Assert.AreEqual(string.Join(",",expectedResult), string.Join(",", result.Steps));

        }
    }
}

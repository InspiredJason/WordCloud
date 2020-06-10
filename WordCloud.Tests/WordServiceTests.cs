using System;
using System.Collections.Generic;
using System.Text;
using WordCloud.Application.Services;
using Xunit;
namespace WordCloud.Tests
{
    public class WordServiceTests
    {
        [Fact]
        public void GivenASetOfArticlesWhenTheDictionaryIsCreatedThenArticlesAreRemoved()
        {
            // Arrange
            var testList = new List<string> { "the", "an", "a" };

            // Act
            var service = new WordService();
            var results = service.GetWordCountDictionary(testList);

            // Assert
            Assert.True(results.Count == 0);
        }

        [Fact]
        public void GivenADictionaryWhenWordsAreGeneratedTheCountsAreEqual()
        {
            // Arrange
            Dictionary<string, int> words = new Dictionary<string, int>
            {
                { "test", 3 },
                { "string", 5 },
                { "please", 8 }
            };

            // Act
            var service = new WordService();
            var results = service.GenerateWords(words);

            // Assert
            Assert.Equal(3, results.Count);
            Assert.Equal("test", results[0].Word);
            Assert.Equal(3, results[0].Count);
            Assert.True(results[0].Id.Length > 0);
        }
    }
}

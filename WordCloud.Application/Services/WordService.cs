using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordCloud.Application.Helpers;
using WordCloud.Application.Words;
using WordCloud.Domain;
using WordCloud.Infrastructure;

namespace WordCloud.Application.Services
{
    public class WordService
    {
        /// <summary>
        /// Given an IEnumerable of strings, returns a Dictionary of distinct words and their occuraences
        /// </summary>
        /// <param name="inputWords"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetWordCountDictionary(IEnumerable<string> inputWords)
        {
            Dictionary<string, int> allWords = new Dictionary<string, int>();

            foreach (var textItem in inputWords)
            {
                // Look for all text items where the first character is a letter and desanitise by getting rid of 
                // encoded characters e.g. &nbsp;
                var words = textItem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(word => char.IsLetter(word[0]))
                    .Select(word => HtmlEntity.DeEntitize(word).RemoveIllegalChars(new string[] { ",", "'", "\"" }).ToLower());

                // Now loop through the words and either add to the dictionary with a count of 1 if it doesn't
                // exist, otherwise increment the count by 1 if found
                // Remove articles "a", "the" and "an"
                foreach (var word in words.RemoveStopWords(new string[] { "a", "the", "an" }))
                {

                    if (allWords.ContainsKey(word))
                    {
                        allWords[word] += 1;
                    }
                    else
                    {
                        allWords.Add(word, 1);
                    }
                }
            }
            return allWords;
        }

        /// <summary>
        /// Downloads a given website as a string, then takes the body content
        /// and returns a WordCloudDto representing the top [wordCount] words
        /// </summary>
        /// <param name="url"></param>
        /// <param name="wordCount"></param>
        /// <returns></returns>
        public async Task<WordCloudDto> GetWordsFromSite(string url, int wordCount)
        {
            Dictionary<string, int> allWords = new Dictionary<string, int>();

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(content);

                // Get all text nodes inside the body of the page and exclude any scripts
                var words = doc.DocumentNode
                    .SelectNodes("//body//text()[not(parent::script)]")
                    .Select(node => node.InnerText);

                allWords = GetWordCountDictionary(words);
            }

            var result = new WordCloudDto
            {
                Url = url,
                Words = GenerateWords(allWords.OrderByDescending(w => w.Value).Take(wordCount).ToDictionary(w => w.Key, w => w.Value))
            };

            return result;
        }

        /// <summary>
        /// Returns a list of WordCount where the Id foe each item is hashed
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public List<WordCount> GenerateWords(Dictionary<string, int> words)
        {
            var wordsToSave = words
                .Select(w => {
                    var hash = Encryption.GenerateSaltedHash(w.Key);
                    return new WordCount { Id = hash, Word = w.Key, Count = w.Value };
                });
            return wordsToSave.ToList();
        }

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WordCloud.Application.Words;
using WordCloud.Domain;

namespace WordCloud.Application.Services
{
    public interface IWordService
    {
        List<WordCount> GenerateWords(Dictionary<string, int> words);
        Dictionary<string, int> GetWordCountDictionary(IEnumerable<string> inputWords);
        Task<WordCloudDto> GetWordsFromSite(string url, int wordCount);
    }
}
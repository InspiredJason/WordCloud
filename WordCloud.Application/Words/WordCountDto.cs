using System;
using System.Collections.Generic;
using System.Text;
using WordCloud.Domain;

namespace WordCloud.Application.Words
{
    public class WordCountDto
    {
        public List<WordCount> Words { get; set; } = new List<WordCount>();
    }
}

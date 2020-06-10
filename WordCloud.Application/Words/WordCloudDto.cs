using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WordCloud.Application.Words
{
    public class WordCloudDto : WordCountDto
    {
        [Required]
        [Url]
        public string Url { get; set; }
        public string JsonWords
        {
            get
            {
                return JsonConvert.SerializeObject(Words);
            }
        }
    }
}

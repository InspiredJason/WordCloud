using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordCloud.Domain
{
    public class WordCount
    {
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Word { get; set; }
        public int Count { get; set; }
    }
}

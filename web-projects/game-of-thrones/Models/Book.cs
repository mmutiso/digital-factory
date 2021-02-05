using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameOfThrones.Models
{
    public class Book
    {
        [JsonIgnore]
        public int Id => int.Parse(url.Split("/")[url.Split("/").Length - 1]);
        public string url { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public List<string> authors { get; set; }

        [JsonIgnore]
        public string AuthorString => string.Join(", ", authors);
        public int numberOfPages { get; set; }
        public string publisher { get; set; }
        public string country { get; set; }
        public string mediaType { get; set; }
        public DateTime released { get; set; }
        public List<string> characters { get; set; }
        public List<string> povCharacters { get; set; }
        
       
    }
}

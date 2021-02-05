using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GameOfThrones.Models
{
    public class BookCharacter
    {
        [JsonIgnore]
        public int Id => int.Parse(url.Split("/")[url.Split("/").Length - 1]);
        public string url { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string culture { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public List<string> titles { get; set; }
        public List<string> aliases { get; set; }

        [JsonIgnore]
        public string AliasesString => string.Join(", ", aliases);
        public string father { get; set; }
        public string mother { get; set; }
        public string spouse { get; set; }
        public List<object> allegiances { get; set; }
        public List<string> books { get; set; }
        public List<object> povBooks { get; set; }
        public List<string> tvSeries { get; set; }
        public List<string> playedBy { get; set; }


    }
}

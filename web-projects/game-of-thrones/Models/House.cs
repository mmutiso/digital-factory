﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameOfThrones.Models
{
    public class House
    {
        [JsonIgnore]
        public int Id => int.Parse(url.Split("/")[url.Split("/").Length - 1]);
        public string url { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string coatOfArms { get; set; }
        public string words { get; set; }
        public List<string> titles { get; set; }
        public List<string> seats { get; set; }
        public string currentLord { get; set; }
        public string heir { get; set; }
        public string overlord { get; set; }
        public int OverLordId => int.Parse(overlord.Split("/")[url.Split("/").Length - 1]);
        public string founded { get; set; }
        public string founder { get; set; }
        public string diedOut { get; set; }
        public List<string> ancestralWeapons { get; set; }
        public List<string> cadetBranches { get; set; }
        public List<string> swornMembers { get; set; }


    }
}

using GameOfThrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Services
{
    public static class LinkParser
    {
        public static LinkMeta Parse(string linkHeaderContent)
        {
            string[] parts = linkHeaderContent.Split(",");
            string next = parts[0].Split(";")[0];
            string first = parts[1].Split(";")[0];
            string last = parts[2].Split(";")[0];

        }

        static LinkMetaType GetLinkType(string content)
        {
            string positionString = content.Split("=")[1][1..^1];
            switch(content)
            {
                case "next":
                    return LinkMetaType.Next;
                case "prev":
                    return LinkMetaType.Previous;
                case "first":
                    return LinkMetaType.First;
                case "last":
                    return LinkMetaType.Last;
                default:
                    return LinkMetaType.First;
            }                
        }

        static int GetPageNumber(string link)
        {
            Uri uri = new Uri(link);

            return int.Parse(uri.Query.Split("&")[0].Split("=")[1]);
        }

        static string FetchLinkOnly(string candidate)
        {
            int n = candidate.Length;
            string link = candidate.Skip(1).Take(n - 2).ToString();
            return link;
        }
    }
}

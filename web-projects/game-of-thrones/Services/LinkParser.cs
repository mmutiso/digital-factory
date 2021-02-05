using GameOfThrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Services
{
    public static class LinkParser
    {
        public static List<LinkMeta> Parse(string linkHeaderContent)
        {
            string[] parts = linkHeaderContent.Split(",");
            List<LinkMeta> linkMetas = new List<LinkMeta>(parts.Length);
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];
                LinkMetaType linkMetaType = GetLinkType(part.Split(";")[1]);
                int pages = GetPageNumber(FetchLinkOnly(part.Split(";")[0]));

                linkMetas.Add(new LinkMeta() { Page = pages, Type = linkMetaType });
            }

            return linkMetas;
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
            string link = candidate[1..^1].ToString();
            return link;
        }
    }
}

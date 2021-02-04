using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Services
{
    public static class RelativePaths 
    {
        public static string BooksEndpoint => "/api/books";
        public static string CharactersEndpoint => "/api/characters";
        public static string HousesEndpoint => "/api/houses";
    }
}

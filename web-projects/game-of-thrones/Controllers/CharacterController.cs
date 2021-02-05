using GameOfThrones.Models;
using GameOfThrones.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Controllers
{
    public class CharacterController : Controller
    {
        HttpWrapper httpWrapper;
        ILogger<BookController> logger;

        public CharacterController(HttpWrapper httpWrapper, ILogger<BookController> logger)
        {
            this.httpWrapper = httpWrapper;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<BookCharacter> books = await httpWrapper.GetAsync<List<BookCharacter>>(RelativePaths.CharactersEndpoint);

            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            BookCharacter book = await httpWrapper.GetAsync<BookCharacter>($"{RelativePaths.CharactersEndpoint}/{id}");

            return View(book);
        }
    }
}

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
    public class BookController : Controller
    {
        HttpWrapper httpWrapper;
        ILogger<BookController> logger;

        public BookController(HttpWrapper httpWrapper, ILogger<BookController> logger)
        {
            this.httpWrapper = httpWrapper;
            this.logger = logger;
        }

        public async Task<IActionResult> Index(int page)
        {
            var response = await httpWrapper.GetAsync<List<Book>>(RelativePaths.BooksEndpoint, page);

            var navigationControls = LinkParser.Parse(response.LinkHeader);

            ViewBag.controls = new NavigationControls(navigationControls);

            return View(response.HttpResponse);
        }

        public async Task<IActionResult> Details(int id)
        {
            Book book = await httpWrapper.GetAsync<Book>($"{RelativePaths.BooksEndpoint}/{id}");

            return View(book);
        }
    }
}

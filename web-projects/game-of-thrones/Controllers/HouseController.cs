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
    public class HouseController : Controller
    {
        HttpWrapper httpWrapper;
        ILogger<HouseController> logger;

        public HouseController(HttpWrapper httpWrapper, ILogger<HouseController> logger)
        {
            this.httpWrapper = httpWrapper;
            this.logger = logger;
        }
        public async Task<IActionResult> Index(int page)
        {
            var houses = await httpWrapper.GetAsync<List<House>>(RelativePaths.HousesEndpoint, page);

            return View(houses.HttpResponse);
        }

        public async Task<IActionResult> Details(int id)
        {
            House house = await httpWrapper.GetAsync<House>($"{RelativePaths.HousesEndpoint}/{id}");

            return View(house);
        }
    }
}

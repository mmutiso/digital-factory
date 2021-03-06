﻿using GameOfThrones.Models;
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
        ILogger<CharacterController> logger;

        public CharacterController(HttpWrapper httpWrapper, ILogger<CharacterController> logger)
        {
            this.httpWrapper = httpWrapper;
            this.logger = logger;
        }
        public async Task<IActionResult> Index(int page)
        {
            var characters = await httpWrapper.GetAsync<List<BookCharacter>>(RelativePaths.CharactersEndpoint, page);

            var navigationControls = LinkParser.Parse(characters.LinkHeader);
            ViewBag.controls = new NavigationControls(navigationControls);

            return View(characters.HttpResponse);
        }

        public async Task<IActionResult> Details(int id)
        {
            BookCharacter character = await httpWrapper.GetAsync<BookCharacter>($"{RelativePaths.CharactersEndpoint}/{id}");

            return View(character);
        }
    }
}

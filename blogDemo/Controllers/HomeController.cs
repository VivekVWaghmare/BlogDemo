using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogDemo.Models;
using BlogDemo.Interfaces;

namespace BlogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _DataService;
        public HomeController(IDataService dataService)
        {
            _DataService = dataService;
        }

        [Route("Post")]
        [HttpGet]
        public async Task<IActionResult> CreatePost(Post model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Validation", "Please provide model values");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post model)
        {
            model.PostDateTime = DateTime.Now;
            await _DataService.Create(model);
            //return View("CreatePost", model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _DataService.GetAll();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

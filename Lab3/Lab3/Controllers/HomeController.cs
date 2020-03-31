using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Lab3Context db;

        public HomeController(ILogger<HomeController> logger, Lab3Context context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            int selectedIndex = 1;
            SelectList states = new SelectList(db.States, "Id", "Name", selectedIndex);
            ViewBag.States = states;
            SelectList cities = new SelectList(db.Cities.Where(c => c.StateId == selectedIndex), "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }
        public ActionResult GetItems(int id)
        {
            return PartialView(db.Cities.Where(c => c.StateId == id).ToList());
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

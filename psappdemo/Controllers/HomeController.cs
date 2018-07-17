using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using psappdemo.Models;



namespace psappdemo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
             _configuration = configuration;
        }
       
        public IActionResult Index()
        {
            var msg = _configuration["Greeting"];
            return View("Index", msg);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

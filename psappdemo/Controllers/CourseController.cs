using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using psappdemo.Services;
using psappdemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace psappdemo.Controllers
{
    public class CourseController : Controller
    {
        private CourseStore _store;
        public CourseController(CourseStore store)
        {
            _store = store;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var courses = _store.GetCourses();
            return View(courses);
        }

        public async Task<IActionResult> Insert()
        {
            var data = new SeedData().CourseList();
            
            await _store.InsertCourses(data);
            return RedirectToAction("Index");
        }
    }
}

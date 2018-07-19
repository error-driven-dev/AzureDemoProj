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

        public async Task<IActionResult> Insert(Course course)
        {
            var clips = new List<Clip>();
            var newClip = new Clip { Name = "Clip 1", Length = 20 };
            clips.Add(newClip);
            var modules = new List<Module>();
            var newMod = new Module { Name = "My first Module", Clips = clips };
            modules.Add(newMod);

            var newCourse = new Course()
            {
                Name = "Welcome!",
                Modules = modules
            };
            await _store.InsertCourses(newCourse);
            return RedirectToAction("Index");
        }
    }
}

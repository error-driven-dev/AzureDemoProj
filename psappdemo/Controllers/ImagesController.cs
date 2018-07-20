using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psappdemo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace psappdemo.Controllers
{
    public class ImagesController : Controller
    {
        ImageStore _store;
        public ImagesController(ImageStore store)
        {
            _store = store;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload(IFormFile photo)
        {
            using(var stream = photo.OpenReadStream())
            {
                var imageName = await _store.SaveImage(stream);
                return RedirectToAction("GetImage", new { imageName });
            }
          
        }

        public IActionResult GetImage(string imageName)
        {
            var link = _store.UriFor(imageName);
            return View("GetImage", link);
        }
    }
}

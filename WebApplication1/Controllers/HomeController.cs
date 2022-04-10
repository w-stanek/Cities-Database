using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        private readonly CityDbContext _db;

        public HomeController(ILogger<HomeController> logger, CityDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            IEnumerable<City> Cities = _db.Cities;

            return View(Cities);
        }

        [HttpPost]

        public IActionResult CreatePost(City city) {
            if (city.Name != null) {
                _db.Cities.Add(city);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetCityById(int id) {
            var city = _db.Cities.Find(id);
            if (city != null)
                return Ok(city);
            else
                return NotFound(city);
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            var city = _db.Cities.Find(id);
            if (city != null) {
                _db.Cities.Remove(city);
                _db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

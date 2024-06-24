using KhumaloTest.Data;
using KhumaloTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KhumaloTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly KhumaloTestContext _context;

        public HomeController(KhumaloTestContext context)
        {
            _context = context;
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult MyWork()
        {
            var craftworks = _context.Craftworks.ToList();
            return View(craftworks);
        }
    }
}

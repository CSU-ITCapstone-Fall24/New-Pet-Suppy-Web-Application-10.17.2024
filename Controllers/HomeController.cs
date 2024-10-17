using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Models;
using System.Diagnostics;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();

        }

        public IActionResult Contact()
        {

            return View();

        }

        public IActionResult ProductNPrices()
        {

            return View();

        }

        public IActionResult FurBabbies()
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

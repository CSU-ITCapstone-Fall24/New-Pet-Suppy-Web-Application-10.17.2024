using Microsoft.AspNetCore.Mvc;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(string name, string email, string subject, string message)
        {
            // Handle form submission (e.g., save to database, send email, etc.)
            ViewBag.Message = "Thank you for contacting us!";
            return View("Index");
        }
    }
}

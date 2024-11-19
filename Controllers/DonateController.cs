using Microsoft.AspNetCore.Mvc;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class DonateController : Controller
    {
        public IActionResult Donate()
        {
            return View();
        }
    }
}

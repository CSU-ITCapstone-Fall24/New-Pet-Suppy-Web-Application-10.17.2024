using Microsoft.AspNetCore.Mvc;
using Pet_Web_Application_10._12._24_F.Data;
using Pet_Web_Application_10._12._24_F.Models;
using System;
using System.Threading.Tasks;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class ContactController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            return View("Index"); // Ensure your view file is named Index.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string name, string email, string subject, string message)
        {
            var contactMessage = new ContactMessage
            {
                Name = name,
                Email = email,
                Subject = subject,
                Message = message,
                SubmittedAt = DateTime.Now
            };

            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Thank you for contacting us!";
            return View("Index"); // Ensure your view file is named Index.cshtml
        }
    }
}
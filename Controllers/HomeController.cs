using JefPortfolio.Helpers;
using JefPortfolio.Models;
using JefPortfolio.Services;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace JefPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService _emailService;
   

        public HomeController(EmailService emailService)
        {
            _emailService = emailService;
        
        }

        // ── GET: / or /Home/Index ─────────────────────────────────────────
        public IActionResult Index()
        {
            ViewBag.SuccessMsg = TempData["Success"];
            TempData.Remove("Success");
            var vm = new PortfolioViewModel
            {
                Skills = Skills.GetSkills(),
                Projects = ProjectsCreated.GetProjects(),
                ContactForm = new ContactForm()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(ContactForm form)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                return Json(new { success = false, errors });
            }

            try
            {
                await _emailService.SendContactEmailAsync(
                    form.Name,
                    form.Email,
                    form.Message
                );

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        // ── POST: /Home/SendMessage ───────────────────────────────────────
        // Handles the contact form submission
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SendMessage(ContactForm form)
        //{
        //    var vm = new PortfolioViewModel
        //    {
        //        Skills = Skills.GetSkills(),
        //        Projects = ProjectsCreated.GetProjects(),
        //        ContactForm = form,
        //        MessageSent = false
        //    };

        //    if (!ModelState.IsValid)
        //    {
        //        // Show what errors exist
        //        foreach (var error in ModelState.Values
        //            .SelectMany(v => v.Errors))
        //        {
        //            Console.WriteLine($"Validation Error: {error.ErrorMessage}");
        //        }
        //        return View("Index", vm);
        //    }

        //    try
        //    {
        //        await _emailService.SendContactEmailAsync(
        //            form.Name,
        //            form.Email,
        //            form.Message
        //        );
        //        vm.MessageSent = true;
        //        vm.ContactForm = new ContactForm();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"EMAIL ERROR: {ex.Message}");
        //        ModelState.AddModelError("", $"Failed to send: {ex.Message}");
        //    }

        //    return View("Index", vm);
        //}


    }
}

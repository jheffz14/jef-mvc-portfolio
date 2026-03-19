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
            var vm = new PortfolioViewModel
            {
                Skills = Skills.GetSkills(),
                Projects = ProjectsCreated.GetProjects(),
                ContactForm = new ContactForm()
            };
            return View(vm);
        }

        // ── POST: /Home/SendMessage ───────────────────────────────────────
        // Handles the contact form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(ContactForm form)
        {
            // If form has errors, go back to page and show errors
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                var vmError = new PortfolioViewModel
                {
                    Skills = Skills.GetSkills(),
                    Projects = ProjectsCreated.GetProjects(),
                    ContactForm = form,  // keep what user typed
                    MessageSent = false
                };
                return View("Index", vmError);
            }

            // Try sending the email
            try
            {
                await _emailService.SendContactEmailAsync(
                    form.Name,
                    form.Email,
                    form.Message
                );
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EMAIL ERROR: {ex.Message}");
            }

            // ✅ Redirect to contact section after sending
            return Redirect("/#contact");
        }


    }
}

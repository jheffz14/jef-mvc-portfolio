using Microsoft.AspNetCore.Mvc;
using JefPortfolio.Models;
using JefPortfolio.Helpers;
using JefPortfolio.Services;

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
            var vm = new PortfolioViewModel
            {
                Skills = Skills.GetSkills(),
                Projects = ProjectsCreated.GetProjects(),
                ContactForm = form,
                MessageSent = false
            };

            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            try
            {
                // Send the email
                await _emailService.SendContactEmailAsync(
                    form.Name,
                    form.Email,
                    form.Message
                );

                vm.MessageSent = true;
                vm.ContactForm = new ContactForm(); // Clear form
            }
            catch (Exception ex)
            {
                // If email fails, show
                ModelState.AddModelError("", $"Error: {ex.Message}");
                //ModelState.AddModelError("", "Failed to send message. Please try again.");
            }

            return View("Index", vm);
        }


        // TEMPORARY - just for testing email
        public async Task<IActionResult> TestEmail()
        {
            try
            {
                await _emailService.SendContactEmailAsync(
                    "Test User",
                    "test@test.com",
                    "This is a test message"
                );
                return Content("✅ Email sent successfully! Check your inbox.");
            }
            catch (Exception ex)
            {
                return Content($"❌ Error: {ex.Message} \n\n Details: {ex.ToString()}");
            }
        }

    }
}

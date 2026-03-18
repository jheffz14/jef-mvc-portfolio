using Microsoft.AspNetCore.Mvc;
using JefPortfolio.Models;
using JefPortfolio.Helpers; 

namespace JefPortfolio.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult SendMessage(ContactForm form)
        {
            var vm = new PortfolioViewModel
            {
                Skills = Skills.GetSkills(),
                Projects = ProjectsCreated.GetProjects(),
                ContactForm = form,
                MessageSent = ModelState.IsValid
            };

            if (!ModelState.IsValid)
            {
                // If form has errors, go back to the page with errors shown
                return View("Index", vm);
            }

            // ✅ Here you would normally send an email or save to a database
            // For now, we just show a success message
            vm.ContactForm = new ContactForm(); // Clear the form
            return View("Index", vm);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using JefPortfolio.Models;

namespace JefPortfolio.Controllers
{
    public class HomeController : Controller
    {
        // ── Seed Data ────────────────────────────────────────────────────────
        // This is where you edit your skills and projects!

        private List<Skill> GetSkills() => new()
        {
            new Skill { Name = "HTML / CSS",    Level = 90, Category = "Frontend" },
            new Skill { Name = "JavaScript",    Level = 85, Category = "Frontend" },
            new Skill { Name = "ASP.NET MVC",   Level = 75, Category = "Backend"  },
            new Skill { Name = "C#",            Level = 72, Category = "Backend"  },
            new Skill { Name = "Git & GitHub",  Level = 75, Category = "Tools"    },
            new Skill { Name = "SQL / EF Core", Level = 68, Category = "Backend"  },
            new Skill { Name = "Bootstrap 5",   Level = 82, Category = "Frontend" },
            new Skill { Name = "Visual Studio", Level = 88, Category = "Tools"    },
        };

        private List<Project> GetProjects() => new()
        {
            new Project
            {
                Id = 1,
                Title = "E-Commerce Site",
                Description = "A full-stack online store with product listing, cart, and checkout built in ASP.NET MVC.",
                Tags = new() { "ASP.NET", "C#", "SQL", "Bootstrap" },
                AccentColor = "#00f5c4",
                Link = "#"
            },
            new Project
            {
                Id = 2,
                Title = "Portfolio v1",
                Description = "My first personal portfolio site built with pure HTML, CSS, and JavaScript.",
                Tags = new() { "HTML", "CSS", "JS" },
                AccentColor = "#7b6cff",
                Link = "#"
            },
            new Project
            {
                Id = 3,
                Title = "Weather Dashboard",
                Description = "Real-time weather app using OpenWeatherMap API and Razor Pages for dynamic rendering.",
                Tags = new() { "ASP.NET", "API", "Razor" },
                AccentColor = "#ff6c6c",
                Link = "#"
            },
            new Project
            {
                Id = 4,
                Title = "Task Manager",
                Description = "A Kanban-style task manager with full CRUD operations and SQL Server database.",
                Tags = new() { "MVC", "EF Core", "SQL" },
                AccentColor = "#ffc94d",
                Link = "#"
            },
        };

        // ── GET: / or /Home/Index ─────────────────────────────────────────
        public IActionResult Index()
        {
            var vm = new PortfolioViewModel
            {
                Skills = GetSkills(),
                Projects = GetProjects(),
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
                Skills = GetSkills(),
                Projects = GetProjects(),
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

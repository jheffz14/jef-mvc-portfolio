using System.ComponentModel.DataAnnotations;

namespace JefPortfolio.Models
{
    // Represents one skill (e.g. HTML/CSS at 90%)
    public class Skill
    {
        public string Name { get; set; } = "";
        public int Level { get; set; }       // 0–100
        public string Category { get; set; } = "";
    }

    // Represents one project card
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Tags { get; set; } = new();
        public string AccentColor { get; set; } = "#00f5c4";
        public string Link { get; set; } = "#";

        // ✅ ADD THIS — list of screenshot paths for the carousel
        public List<POSSlide> Slides { get; set; } = new();
    }

    // ✅ ADD THIS NEW CLASS below Project
    public class POSSlide
    {
        public string Icon { get; set; } = "";         // emoji icon
        public string Title { get; set; } = "";        // utility name
        public string Caption { get; set; } = "";      // description
        public List<string> Tags { get; set; } = new(); // tech tags
        public string ImagePath { get; set; } = "";   // ✅ ADD THIS LINE
    }



    // Represents a contact form submission
    public class ContactForm
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            ErrorMessage = "Please enter a valid email address")]
        public string Message { get; set; } = "";

        [Required(ErrorMessage = "Message is required")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        public string Email { get; set; } = "";
    }

    // The main ViewModel — combines everything for the single-page portfolio
    public class PortfolioViewModel
    {
        public List<Skill> Skills { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public ContactForm ContactForm { get; set; } = new();
        public bool MessageSent { get; set; } = false;

    }




}

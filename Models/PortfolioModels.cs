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
    }

    // Represents a contact form submission
    public class ContactForm
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
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

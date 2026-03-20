using JefPortfolio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JefPortfolio.Services
{
    public class SkillsService
    {
        public List<Skill> GetSkills() => new()
        {
            new Skill { Name = "HTML / CSS",Category = "Frontend" },
            new Skill { Name = "JavaScript",Category = "Frontend" },
            new Skill { Name = "ASP.NET MVC",Category = "Backend"  },
            new Skill { Name = "C#", Category = "Backend"  },
            new Skill { Name = "GitHub", Category = "Tools"    },
            new Skill { Name = "SQL",  Category = "Backend"  },
            new Skill { Name = "Bootstrap 5", Category = "Frontend" },
            new Skill { Name = "Visual Studio 2026", Category = "IDE"    },
            new Skill { Name = "Visual Studio Code", Category = "IDE"    },
            new Skill { Name = "ChatGpt", Category = "AI"    },
            new Skill { Name = "ClaudeAi", Category = "AI"    },
            new Skill { Name = "DeepSeek Ai", Category = "AI"    },
        };
    }
}

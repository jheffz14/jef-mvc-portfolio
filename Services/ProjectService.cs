using JefPortfolio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace JefPortfolio.Services
{
    public class ProjectService
    {
        public List<Project> GetProjects() => new()
        {
              new Project
            {
                Id = 1,
                Title = "POS Utilities",
                Description = @"A web-based internal management system built with ASP.NET Core MVC and SQL Server. 
                                  Designed for retail store operations.",
                Tags = new() { "ASP.net Core MVC", "SQL Server", "C#" },
                AccentColor = "#ffc94d",
                Link = "#",
                Slides = new()
          {
        new POSSlide
        {
           Icon = "🧾",
           Title = "Transaction Utilities",
           ImagePath = "/img/trans_utils.png",   // ✅ path to wwwroot/images/
           Caption = "POS transaction per store.",
           Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "📊",
            Title = "EPA Reports",
            ImagePath = "/img/epa_reports.png",   // ✅ path to wwwroot/images/
            Caption = "Reports regarding Bonus and Kanegosyo cards.",
             Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "👤",
            Title = "Add Employee",
            ImagePath = "/img/add_employee.png",   // ✅ path to wwwroot/images/
            Caption = "Register and update cashier/operator accounts across multiple stores.",
              Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "🏷️",
            Title = "Promo Checker",
            ImagePath = "/img/promo_checker.png",   // ✅ path to wwwroot/images/
            Caption = "Validate and manage promotional discount rules.",
            Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "🔐",
            Title = "Sale Validation",
            ImagePath = "/img/sale_validation.png",   // ✅ path to wwwroot/images/
            Caption = "Manage user credentials and profiles for POS Sale validation.",
              Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "🏷️",
            Title = "Discount Checker",
            ImagePath = "/img/discount_checker.png",   // ✅ path to wwwroot/images/
            Caption = "Manage PWD and Senior Citizen discount settings with pagination.",
              Tags = new() { "ASP.NET MVC", "C#", "SQL Server" }
        },
        new POSSlide
        {
            Icon = "💰",
            Title = "Cashier transaction Viewer",
            ImagePath = "/img/cashier_trans.png",   // ✅ path to wwwroot/images/
            Caption = "View and monitor cashier transaction history by payment type.",
            Tags = new() { "ASP.NET MVC", "SQL Server" }
        }
    }
            },

            new Project
            {
                Id = 2,
                Title = "AI Exercise Generator",
                Description = @"This generator is a fully automated Python pipeline 
                              that creates complete workout videos from scratch.",
                Tags = new() { "Python" },
                AccentColor = "#7b6cff",
                Link = "https://github.com/jheffz14/AI_Exercise_Generator"
            },
            new Project
            {
                Id = 3,
                Title = "Printer Repair Tool ",
                Description = @"A Windows batch-based troubleshooting toolkit designed to automatically diagnose and 
                                repair common printer, spooler, network, and driver issues on Windows systems.",
                Tags = new() { "Batch File" },
                AccentColor = "#ffc94d",
                Link = "https://github.com/jheffz14/Printer-Repair-tool"

            }

        };
    }
}

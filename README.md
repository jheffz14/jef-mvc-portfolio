
https://jef-mvc-portfolio-production.up.railway.app/

# 👨‍💻 Jef's Portfolio — ASP.NET Core MVC

A modern, futuristic portfolio built with **ASP.NET Core MVC (.NET 8)**.

---

## 📁 Project Structure — What Each File Does

```
JefPortfolio/
│
├── Controllers/
│   └── HomeController.cs      ← The BRAIN. Handles page requests & form submissions.
│                                 Edit your skills and projects DATA here.
│
├── Models/
│   └── PortfolioModels.cs     ← The DATA SHAPES. Defines what a Skill/Project looks like.
│
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml     ← The WRAPPER. Navbar + Footer shared across all pages.
│   ├── Home/
│   │   └── Index.cshtml       ← The MAIN PAGE. All your portfolio sections (HTML + Razor).
│   ├── _ViewStart.cshtml      ← Tells all views to use _Layout automatically.
│   └── _ViewImports.cshtml    ← Imports namespaces so you don't repeat them everywhere.
│
├── wwwroot/
│   ├── css/site.css           ← All your STYLES (colors, layout, animations).
│   └── js/site.js             ← All your JAVASCRIPT (scroll effects, skill bars, filter).
│
├── Program.cs                 ← App STARTUP. Configures MVC and the request pipeline.
├── appsettings.json           ← App SETTINGS (logging, connection strings, etc.)
└── JefPortfolio.csproj        ← Project FILE. Tells .NET what type of project this is.
```

---

## ▶️ How to Run in Visual Studio

### STEP 1 — Install .NET 8 SDK
Download from: https://dotnet.microsoft.com/download/dotnet/8.0
(Choose ".NET 8.0 SDK" — the one that says SDK, not Runtime)

### STEP 2 — Open the project
1. Open **Visual Studio**
2. Click **"Open a project or solution"**
3. Navigate to your folder and select **`JefPortfolio.csproj`**

### STEP 3 — Run it
- Press **F5** (or click the green ▶ Play button)
- Your browser will open automatically at `https://localhost:XXXX`
- You'll see your portfolio! 🎉

> If Visual Studio asks to install .NET 8 workloads — say Yes and let it install.

---

## ✏️ How to Customize Your Portfolio

### Change your Skills → `Controllers/HomeController.cs`
Find the `GetSkills()` method and edit the list:
```csharp
new Skill { Name = "React JS", Level = 80, Category = "Frontend" },
```

### Change your Projects → `Controllers/HomeController.cs`
Find the `GetProjects()` method and edit the list:
```csharp
new Project {
    Title = "My Cool App",
    Description = "What the project does...",
    Tags = new() { "ASP.NET", "SQL" },
    AccentColor = "#00f5c4",
    Link = "https://github.com/jef/my-app"
},
```

### Change Colors → `wwwroot/css/site.css`
Look for `:root { }` at the very top:
```css
--accent:  #00f5c4;   /* Main green color */
--accent2: #7b6cff;   /* Purple accent */
--bg:      #080b14;   /* Background */
```

---

## 🌿 GIT GUIDE — Your First Time Using Git

> Git = a tool that saves the HISTORY of your code (like undo, but forever).
> GitHub = a website to store your code online.

### STEP 1 — Install Git
Download from: https://git-scm.com → Install with all defaults

Check it works (in Visual Studio Terminal or CMD):
```bash
git --version
```

### STEP 2 — Set your identity (once ever)
```bash
git config --global user.name "Jef"
git config --global user.email "your@email.com"
```

### STEP 3 — Initialize Git in your project
Open a terminal, navigate to your project folder:
```bash
cd D:\Jef\jef-mvc-portfolio
git init
```

### STEP 4 — Save your first snapshot
```bash
git add .
git commit -m "Initial commit: Jef MVC portfolio"
```

| Command | What it does |
|---|---|
| `git add .` | Stages ALL files (puts them in the "envelope") |
| `git commit -m "..."` | Saves a snapshot with your message |
| `git status` | Shows what files changed |
| `git log` | Shows all your past commits |

### STEP 5 — Put it on GitHub
1. Go to https://github.com → Sign up / Login
2. Click **+** → **New repository** → name it `jef-mvc-portfolio` → **Create**
3. Run these in your terminal:
```bash
git remote add origin https://github.com/YOUR-USERNAME/jef-mvc-portfolio.git
git branch -M main
git push -u origin main
```
✅ Your code is now live on GitHub!

### Every time you make changes:
```bash
git add .
git commit -m "what I changed"
git push
```

---

Built with ❤️ by Jef

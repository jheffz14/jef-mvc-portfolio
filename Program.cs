using JefPortfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services here
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<JefPortfolio.Services.EmailService>();
builder.Services.AddScoped<JefPortfolio.Services.ProjectService>();
builder.Services.AddScoped<JefPortfolio.Services.SkillsService>();

var app = builder.Build();


// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route: /Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

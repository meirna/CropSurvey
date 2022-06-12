using CropSurvey.Data;
using CropSurvey.Model;
using CropSurvey.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        opt => opt.MigrationsAssembly("CropSurvey.DAL")
    ));
builder.Services
    .AddDefaultIdentity<AppUser>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddUserValidator<OptionalEmailUserValidator<AppUser>>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services
    .AddAuthentication()
    .AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = builder.Environment.IsProduction() ? Environment.GetEnvironmentVariable("CLIENT_ID") : builder.Configuration["Authentication:Google:ClientId"];
            googleOptions.ClientSecret = builder.Environment.IsProduction() ? Environment.GetEnvironmentVariable("CLIENT_SECRET") : builder.Configuration["Authentication:Google:ClientSecret"];
        });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "o-projektu",
    pattern: "o-projektu",
    defaults: new { controller = "Home", action = "About" });
app.MapControllerRoute(
    name: "o-autoru",
    pattern: "o-autoru",
    defaults: new { controller = "Home", action = "AboutMe" });
app.MapControllerRoute(
    name: "anketa",
    pattern: "anketa",
    defaults: new { controller = "Survey", action = "Index" });
app.MapControllerRoute(
    name: "anketa/start",
    pattern: "anketa/start",
    defaults: new { controller = "Survey", action = "Start" });
app.MapControllerRoute(
    name: "anketa/pitanje",
    pattern: "anketa/pitanje/{ID}",
    defaults: new { controller = "Survey", action = "Question" });
app.MapControllerRoute(
    name: "anketa/submit",
    pattern: "anketa/submit",
    defaults: new { controller = "Survey", action = "Submit" });
app.MapControllerRoute(
    name: "anketa/kraj",
    pattern: "anketa/kraj",
    defaults: new { controller = "Survey", action = "Done" });
app.MapControllerRoute(
    name: "admin",
    pattern: "admin",
    defaults: new { controller = "Admin", action = "Index" });
app.MapControllerRoute(
    name: "admin/detalji",
    pattern: "detalji/{ID}",
    defaults: new { controller = "Admin", action = "Details" });
app.MapControllerRoute(
    name: "admin/update-user",
    pattern: "update-user",
    defaults: new { controller = "Admin", action = "EditUser" });
app.MapControllerRoute(
    name: "admin/delete-user",
    pattern: "delete-user/{ID}",
    defaults: new { controller = "Admin", action = "DeleteUser", ID = "ID" });
app.MapControllerRoute(
    name: "admin/delete-rating",
    pattern: "delete-rating/{ID}",
    defaults: new { controller = "Admin", action = "DeleteRating", ID = "ID" });
app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Home", action = "Index" });
app.MapRazorPages();

app.Run();

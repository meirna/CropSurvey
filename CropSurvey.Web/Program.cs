using CropSurvey.Data;
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
    .AddDefaultIdentity<IdentityUser>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddUserValidator<OptionalEmailUserValidator<IdentityUser>>()
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

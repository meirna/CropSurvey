using System.Diagnostics;
using CropSurvey.Data;
using CropSurvey.Model;
using CropSurvey.Models;
using CropSurvey.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CropSurvey.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext, userManager)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var response = await GetUserRatingCount();
            ViewData["completed"] = response;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> AboutAsync()
        {
            var response = await GetUserRatingCount();
            ViewData["completed"] = response;

            return View();
        }

        public async Task<IActionResult> AboutMeAsync()
        {
            var response = await GetUserRatingCount();
            ViewData["completed"] = response;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
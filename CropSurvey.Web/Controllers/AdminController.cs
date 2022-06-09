using CropSurvey.Data;
using CropSurvey.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CropSurvey.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        protected ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var response = await GetUserDTOListAsync();

            return View(response);
        }

        private async Task<List<UserDTO>> GetUserDTOListAsync()
        {
            var responseUsers = this._dbContext
                .Users
                .Select(u => new UserDTO
                {
                    UserID = u.Id,
                    UserName = u.UserName,
                    WantResults = u.WantResults,
                })
                .ToList();

            var responseRatings = this._dbContext
                .Ratings!
                .GroupBy(r => r.UserID)
                .Select(r => new UserDTO
                {
                    UserID = r.First().UserID,
                    RatingCount = r.Count()
                })
                .ToList();

            foreach (var rating in responseRatings)
            {
                foreach (var user in responseUsers)
                {
                    if (rating.UserID == user.UserID)
                        user.RatingCount = rating.RatingCount;
                }
            }

            return responseUsers;
        }
    }
}

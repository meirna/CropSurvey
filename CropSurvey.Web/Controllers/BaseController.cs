using CropSurvey.Data;
using CropSurvey.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CropSurvey.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext _dbContext;
        protected UserManager<AppUser> _userManager;

        public BaseController(ApplicationDbContext _dbContext, UserManager<AppUser> _userManager)
        {
            this._dbContext = _dbContext;
            this._userManager = _userManager;
        }

        public string UserID { get { return this._userManager.GetUserId(base.User); } }

        protected async Task<int> GetUserRatingCount()
        {
            return await this._dbContext
                .Ratings!
                .Where(r => r.UserID == this.UserID)
                .CountAsync();
        }

        protected async Task<int> GetPhotosCount()
        {
            return await this._dbContext
                .Photos!
                .CountAsync();
        }

        protected async Task<int> GetCompletedQuestionsCount()
        {
            return await GetUserRatingCount() / 2;
        }

        protected async Task<int> GetTotalQuestionsCount()
        {
            return await GetPhotosCount() * 2;
        }
    }
}

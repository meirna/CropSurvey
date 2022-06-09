using CropSurvey.Data;
using CropSurvey.Model;
using CropSurvey.Models;
using CropSurvey.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CropSurvey.Web.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        protected ApplicationDbContext _dbContext;
        protected UserManager<AppUser> _userManager;

        public SurveyController(ApplicationDbContext dbContext, UserManager<AppUser> userManager)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
        }

        public string UserID { get { return this._userManager.GetUserId(base.User); } }

        public async Task<IActionResult> IndexAsync()
        {
            var response = await GetUserRatingCount();
            ViewData["completed"] = response / 2;

            return View();
        }

        public IActionResult Start()
        {
            return View();
        }

        public async Task<IActionResult> Done()
        {
            var response = await GetUserRatingCount();
            if (response != 60)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> QuestionAsync(int ID = 1)
        {
            if (ID < 1 || ID > 30)
                return RedirectToAction("Question", new { ID = 1 });

            var skipN = (ID % 15) - 1;
            var response = await this._dbContext
                .Photos!
                .Include(p => p.Crops!.OrderBy(c => c.ID))
                .OrderBy(p => p.ID)
                .Skip(skipN >= 0 ? skipN : 14)
                .FirstAsync();

            var is1x1 = ID <= 15;
            var CropA = response.Crops.ElementAt(is1x1 ? 0 : 2).ID;
            var CropB = response.Crops.ElementAt(is1x1 ? 1 : 3).ID;
            var RatingA = await GetCropRatingAsync(CropA);
            var RatingB = await GetCropRatingAsync(CropB);
            var swap = new Random().Next(0, 2) == 0;
            var result = new QuestionDTO
            {
                QuestionID = ID,
                Original = response.ID,
                CropA = swap ? CropB : CropA,
                CropB = swap ? CropA : CropB,
                ValueA = swap ? RatingB?.Value ?? 0 : RatingA?.Value ?? 0,
                ValueB = swap ? RatingA?.Value ?? 0 : RatingB?.Value ?? 0,
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(QuestionDTO questionDTO)
        {
            if (ModelState.IsValid)
            {
                await CreateOrUpdateRatingAsync(questionDTO.CropA, questionDTO.ValueA);
                await CreateOrUpdateRatingAsync(questionDTO.CropB, questionDTO.ValueB);
                await this._dbContext.SaveChangesAsync();
                if (questionDTO.QuestionID == 30)
                    return RedirectToAction("Done");

                return RedirectToAction("Question", new { ID = questionDTO.QuestionID + 1 });
            }

            return RedirectToAction("Question", new { ID = questionDTO.QuestionID });
        }

        private async Task<Rating?> GetCropRatingAsync(string ID)
        {
            return await this._dbContext
                .Ratings!
                .Where(r => r.UserID == this.UserID && r.CropID == ID)
                .FirstOrDefaultAsync();
        }

        private async Task CreateOrUpdateRatingAsync(string CropID, int Value)
        {
            var response = await GetCropRatingAsync(CropID);
            if (response != null)
            {
                if (response.Value != Value)
                {
                    response.Value = Value;
                    response.Modified = DateTime.Now;
                    await this.TryUpdateModelAsync(response);
                }
            } else
            {
                var rating = new Rating
                {
                    UserID = this.UserID,
                    CropID = CropID,
                    Value = Value,
                    Created = DateTime.Now,
                };
                await this._dbContext.Ratings!.AddAsync(rating);
            }
        }

        private async Task<int> GetUserRatingCount()
        {
            return await this._dbContext
                .Ratings!
                .Where(r => r.UserID == this.UserID)
                .CountAsync();
        }
    }
}

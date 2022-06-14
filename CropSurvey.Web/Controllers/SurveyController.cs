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
    public class SurveyController : BaseController
    {
        public SurveyController(ApplicationDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext, userManager) { }

        public async Task<IActionResult> IndexAsync()
        {
            ViewData["completedCount"] = await GetCompletedQuestionsCount();
            ViewData["totalCount"] = await GetTotalQuestionsCount();

            return View();
        }

        public async Task<IActionResult> StartAsync()
        {
            ViewData["completedCount"] = await GetCompletedQuestionsCount();
            ViewData["totalCount"] = await GetTotalQuestionsCount();

            return View();
        }

        public async Task<IActionResult> Done()
        {
            var completedCount = await GetCompletedQuestionsCount();
            var totalCount = await GetTotalQuestionsCount() * 2;
            if (completedCount != totalCount)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> QuestionAsync(int ID = 1)
        {
            var photosCount = await GetPhotosCount();
            var totalQuestionsCount = photosCount * 2;
            if (ID < 1 || ID > totalQuestionsCount)
                return RedirectToAction("Question", new { ID = 1 });

            var skipN = (ID % photosCount) - 1;
            var response = await this._dbContext
                .Photos!
                .Include(p => p.Crops!.OrderBy(c => c.ID))
                .OrderBy(p => p.ID)
                .Skip(skipN >= 0 ? skipN : photosCount-1)
                .FirstAsync();

            var is1x1 = ID <= photosCount;
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
            ViewData["totalCount"] = totalQuestionsCount;
            ViewData["is1x1"] = is1x1;

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
                var questionsCount = await GetTotalQuestionsCount();
                if (questionDTO.QuestionID == questionsCount)
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
    }
}

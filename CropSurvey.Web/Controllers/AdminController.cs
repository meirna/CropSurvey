using CropSurvey.Data;
using CropSurvey.Model;
using CropSurvey.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CropSurvey.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        protected ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(ApplicationDbContext dbContext, UserManager<AppUser> userManager)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var response = await GetUserDTOListAsync();

            return View(response);
        }

        public async Task<IActionResult> Details(string ID, bool? ok)
        {
            var response = await this._dbContext
                .Users
                .Where(u => u.Id == ID)
                .Include(u => u.Ratings)
                .FirstOrDefaultAsync();
            this.FillGenderDropdown();
            this.FillKnowledgeLevelDropdown();
            if (ok == true)
                ViewData["StatusMessage"] = "Promjene su uspješno spremljene.";
            else if (ok == false)
                ViewData["StatusMessage"] = "Došlo je do pogreške.";

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(AppUser Model)
        {
            if (ModelState.IsValid)
            {
                var user = await this._userManager.FindByIdAsync(Model.Id);
                user.Email = Model.Email;
                user.Age = Model.Age;
                user.WantResults = Model.WantResults;
                user.GenderID = Model.GenderID;
                user.KnowledgeLevelID = Model.KnowledgeLevelID;
                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    return RedirectToAction("Details", new { ID = Model.Id, ok = true });
                }
            }

            return RedirectToAction("Details", new { ID = Model.Id, ok = false });
        }

        private async Task<List<UserDTO>> GetUserDTOListAsync()
        {
            var responseUsers = await this._dbContext
                .Users
                .Select(u => new UserDTO
                {
                    UserID = u.Id,
                    UserName = u.UserName,
                    WantResults = u.WantResults,
                })
                .ToListAsync();

            var responseRatings = await this._dbContext
                .Ratings!
                .GroupBy(r => r.UserID)
                .Select(r => new UserDTO
                {
                    UserID = r.First().UserID,
                    RatingCount = r.Count()
                })
                .ToListAsync();

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

        private void FillGenderDropdown()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberi -";
            listItem.Value = "";
            selectItems.Add(listItem);
            foreach (var category in this._dbContext.Genders)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewData["Genders"] = selectItems;
        }

        private void FillKnowledgeLevelDropdown()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberi -";
            listItem.Value = "";
            selectItems.Add(listItem);
            foreach (var category in this._dbContext.KnowledgeLevels)
            {
                listItem = new SelectListItem(category.Name, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewData["KnowledgeLevels"] = selectItems;
        }
    }
}

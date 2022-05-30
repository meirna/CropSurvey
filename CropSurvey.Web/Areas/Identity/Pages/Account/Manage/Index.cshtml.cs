// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CropSurvey.Data;
using CropSurvey.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CropSurvey.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            [EmailAddress(ErrorMessage = "Molimo unesite ispravnu email adresu.")]
            public string? Email { get; set; }

            [Range(1, 100, ErrorMessage = "Molimo unesite broj godina.")]
            public int? Age { get; set; }

            public bool WantResults { get; set; }

            public int? GenderID { get; set; }

            public Gender? Gender { get; set; }

            public int? KnowledgeLevelID { get; set; }

            public KnowledgeLevel? KnowledgeLevel { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = user.Email,
                Age = user.Age,
                WantResults = user.WantResults ?? false,
                GenderID = user.GenderID,
                Gender = user.Gender,
                KnowledgeLevelID = user.KnowledgeLevelID,
                KnowledgeLevel = user.KnowledgeLevel,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            FillGenderDropdown();
            FillKnowledgeLevelDropdown();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Email != user.Email) user.Email = Input.Email;
            if (Input.Age != user.Age) user.Age = Input.Age;
            if (Input.WantResults != user.WantResults) user.WantResults = Input.WantResults;
            if (Input.GenderID != user.GenderID) user.GenderID = Input.GenderID;
            if (Input.KnowledgeLevelID != user.KnowledgeLevelID) user.KnowledgeLevelID = Input.KnowledgeLevelID;
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Došlo je do pogreške.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Promjene su uspješno spremljene.";
            return RedirectToPage();
        }

        private void FillGenderDropdown()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "";
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
            listItem.Text = "";
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

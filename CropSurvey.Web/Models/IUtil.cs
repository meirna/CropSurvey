using CropSurvey.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CropSurvey.Web.Models
{
    public interface IUtil
    {
        private static List<SelectListItem> InitDropdown()
        {
            var selectItems = new List<SelectListItem>();
            var listItem = new SelectListItem();
            listItem.Text = "- odaberi -";
            listItem.Value = "";
            selectItems.Add(listItem);

            return selectItems;
        }

        public static List<SelectListItem> GetGenderDropdown(ApplicationDbContext dbContext)
        {
            var selectItems = InitDropdown();
            foreach (var category in dbContext.Genders)
                selectItems.Add(new SelectListItem(category.Name, category.ID.ToString()));

            return selectItems;
        }

        public static List<SelectListItem> GetKnowlegdeLevelDropdown(ApplicationDbContext dbContext)
        {
            var selectItems = InitDropdown();
            foreach (var category in dbContext.KnowledgeLevels)
                selectItems.Add(new SelectListItem(category.Name, category.ID.ToString()));

            return selectItems;
        }
    }
}

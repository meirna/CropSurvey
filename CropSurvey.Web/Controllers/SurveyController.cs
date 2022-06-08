using Microsoft.AspNetCore.Mvc;

namespace CropSurvey.Web.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            ViewData["completed"] = 0;
            return View();
        }
    }
}

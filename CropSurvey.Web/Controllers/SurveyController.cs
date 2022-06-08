using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CropSurvey.Web.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {       
        public IActionResult Index()
        {
            ViewData["completed"] = 0;
            return View();
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DryCleanerApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = TempData["ErrorMessage"];
            return View();
        }
    }
}

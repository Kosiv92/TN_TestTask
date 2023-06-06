using Microsoft.AspNetCore.Mvc;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PatrolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Infrastructure;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PatrolController : Controller
    {
        private readonly IEfRepository<Patrol> _repository;

        public PatrolController(IEfRepository<Patrol> repository) 
            => _repository = repository;
        

        public async Task<IActionResult> List()
        {
            ViewBag.Patrols = await _repository.GetAll();
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

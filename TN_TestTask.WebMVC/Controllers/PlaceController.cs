using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Infrastructure;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IEfRepository<Place> _repository;

        public PlaceController(IEfRepository<Place> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var places = await _repository.GetAll();
            return View(places);
        }

        //[HttpGet]
        //public IActionResult Create()
        //    => View(new CreatePatrolCommand());

    }
}

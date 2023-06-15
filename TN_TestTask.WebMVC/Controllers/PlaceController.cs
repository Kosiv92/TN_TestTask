using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.WebMVC.Application;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEfRepository<Place> _repository;

        public PlaceController(IEfRepository<Place> repository, IMediator mediator)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
            => View(await _mediator.Send(new GetPlacesListQuery()));
        

        [HttpGet]
        public IActionResult Create()
            => View(new CreatePlaceCommand());

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceCommand request)
        {
            if (!ModelState.IsValid) return View("Create");

            try
            {
                var result = await _mediator.Send(request);
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("List");
        }

    }
}

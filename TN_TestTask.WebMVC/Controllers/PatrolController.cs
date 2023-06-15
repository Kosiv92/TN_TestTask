using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.WebMVC.Application;
using TN_TestTask.WebMVC.Models;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PatrolController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEfRepository<Place> _placeRepository;

        public PatrolController(IMediator mediator, IEfRepository<Place> placeRepository) 
            => (_mediator, _placeRepository) = (mediator, placeRepository);
        
        /// <summary>
        /// Получение списка всех сущностей
        /// </summary>
        /// <param name="title">Настройка фильтрации списка</param>
        /// <param name="sortOrder">Настройка сортировки списка</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> List(string title, SortState sortOrder = SortState.TitleAsc)
        {            
            var request = new GetPatrolsListQuery()
            {
                TitleFilter = title,
                SortOrder = sortOrder
            };

            try
            {
                var viewModel = await _mediator.Send(request);
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        /// <summary>
        /// Получение подробной информации о сущности по ее Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Info([FromRoute] Guid id)
        {
            var request = new GetPatrolQuery { Id = id };

            var places = await _placeRepository.GetAll();
            ViewData["places"] = places.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var patrolDto = await _mediator.Send(request);

            return View(patrolDto);
        }

        [HttpPost("[action]/{id:guid}")]
        public async Task<IActionResult> Edit(UpdatePatrolCommand request)
        {
            if (!ModelState.IsValid) return View("Info", request.Id);

            try
            {
                var result = await _mediator.Send(request);
                return RedirectToAction("Info", new { id = result } );
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        /// <summary>
        /// Удаление сущности по Id номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeletePatrolCommand { Id = id };
            try
            {
                await _mediator.Send(request);
                return RedirectToAction("List");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        /// <summary>
        /// Вызов представления для создания новой сущности
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        { 
            var places = await _placeRepository.GetAll();
            ViewData["places"] = places.Select(x => new SelectListItem{ 
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return View(new CreatePatrolCommand());
        }
           


        /// <summary>
        /// Передача данных для создания новой сущности 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatrolCommand request)
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

        /// <summary>
        /// Вызов представления с сообщением об ошибке
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

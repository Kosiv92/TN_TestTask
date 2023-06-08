using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Infrastructure;
using TN_TestTask.WebMVC.Application;
using TN_TestTask.WebMVC.Models;

namespace TN_TestTask.WebMVC.Controllers
{
    public class PatrolController : Controller
    {
        private readonly IMediator _mediator;

        public PatrolController(IMediator mediator) 
            => _mediator = mediator;
        

        [HttpGet]
        public async Task<IActionResult> List()
        {            
            return View();
        }

        /// <summary>
        /// Вызов представления для создания новой сущности
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
            => View();


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
                await _mediator.Send(request);
            }
            catch(Exception ex)
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

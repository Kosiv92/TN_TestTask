using MediatR;
using System;
using System.ComponentModel.DataAnnotations;


namespace TN_TestTask.WebMVC.Application
{
    public class CreatePatrolCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "Укажите наименование (не более 40 символов)")]
        [StringLength(40, ErrorMessage = "Укажите наименование не более {1} символов")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage = "Укажите наименование не более {1} символов")]
        public string Description { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TN_TestTask.WebMVC.Application
{
    public record CreatePatrolCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "Укажите наименование (не более 40 символов)")]
        [StringLength(40, ErrorMessage = "Укажите наименование не более {1} символов")]
        public string Title { get; init; }

        [StringLength(250, ErrorMessage = "Укажите наименование не более {1} символов")]
        public string Description { get; init; }
    }
}

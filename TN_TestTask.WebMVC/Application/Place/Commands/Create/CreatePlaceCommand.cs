using MediatR;
using System;

namespace TN_TestTask.WebMVC.Application
{
    public class CreatePlaceCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}

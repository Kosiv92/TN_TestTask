using MediatR;
using System;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPatrolQuery : IRequest<PatrolItemDto>
    {
        public Guid Id { get; set; }
    }
}

using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class UpdatePatrolCommandHandler : IRequestHandler<UpdatePatrolCommand, Guid>
    {
        private readonly IEfRepository<Patrol> _repository;                

        public UpdatePatrolCommandHandler(IEfRepository<Patrol> repository)
        {
            _repository = repository;            
        }

        public async Task<Guid> Handle(UpdatePatrolCommand request, CancellationToken cancellationToken)
        {
            var patrol = await _repository.GetByIdAsync(request.Id);

            patrol.Title = request.Title;
            patrol.Description = request.Description;
            patrol.Status = request.Status;
            patrol.PlaceId = Guid.Parse(request.PlaceId);
                        
            await _repository.SaveChangesAsync();

            return patrol.Id;
        }
    }
}

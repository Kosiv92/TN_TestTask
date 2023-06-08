using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Infrastructure;

namespace TN_TestTask.WebMVC.Application
{
    public class DeletePatrolCommandHandler : IRequestHandler<DeletePatrolCommand, Unit>
    {
        private readonly IEfRepository<Patrol> _repository;

        public DeletePatrolCommandHandler(IEfRepository<Patrol> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePatrolCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            await _repository.SaveChangesAsync();
            return default;
        }
    }
}

using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPatrolQueryHandler : IRequestHandler<GetPatrolQuery, PatrolItemDto>
    {
        private readonly IEfRepository<Patrol> _repository;

        private readonly IMapper _mapper;

        public GetPatrolQueryHandler(IEfRepository<Patrol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatrolItemDto> Handle(GetPatrolQuery request, CancellationToken cancellationToken)
        {
            var patrol = await _repository.GetByIdAsync(request.Id);
            var patrolDto = _mapper.Map<PatrolItemDto>(patrol);
            return patrolDto;
        }
    }
}

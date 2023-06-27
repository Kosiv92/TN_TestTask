using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPatrolQueryHandler : IRequestHandler<GetPatrolQuery, PatrolItemDto>
    {
        private readonly IEfRepository<Patrol> _patrolRepository;

        private readonly IEfRepository<Place> _placeRepository;

        private readonly IMapper _mapper;

        public GetPatrolQueryHandler(IEfRepository<Patrol> patrolRepository, IEfRepository<Place> placeRepository, IMapper mapper)
        {
            _patrolRepository = patrolRepository;
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        public async Task<PatrolItemDto> Handle(GetPatrolQuery request, CancellationToken cancellationToken)
        {
            var patrol = await _patrolRepository.GetByIdAsync(request.Id);
            var patrolDto = _mapper.Map<PatrolItemDto>(patrol);

            var places = await _placeRepository.GetAll();
            patrolDto.Places = places.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return patrolDto;
        }
    }
}

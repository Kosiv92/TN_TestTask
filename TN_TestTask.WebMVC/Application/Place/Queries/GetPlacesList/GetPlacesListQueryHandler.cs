using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPlacesListQueryHandler : IRequestHandler<GetPlacesListQuery, IEnumerable<PlaceListItemDto>>
    {
        private readonly IEfRepository<Place> _repository;
        private readonly IMapper _mapper;

        public GetPlacesListQueryHandler(IEfRepository<Place> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaceListItemDto>> Handle(GetPlacesListQuery request, CancellationToken cancellationToken)
        {
            var places = await _repository.GetAll();

            var query = places
                .AsQueryable()
                .ProjectTo<PlaceListItemDto>(_mapper.ConfigurationProvider);

            return query;
        }
    }
}

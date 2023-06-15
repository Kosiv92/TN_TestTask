using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, Guid>
    {
        private readonly IEfRepository<Place> _repository;

        private readonly IMapper _mapper;

        public CreatePlaceCommandHandler(IEfRepository<Place> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = _mapper.Map<CreatePlaceCommand, Place>(request);
            await _repository.CreateAsync(place);
            await _repository.SaveChangesAsync();
            return place.Id;
        }
    }
}

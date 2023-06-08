using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Infrastructure;
using TN_TestTask.Core;
using AutoMapper;

namespace TN_TestTask.WebMVC.Application
{
    public class CreatePatrolCommandHandler : IRequestHandler<CreatePatrolCommand, Guid>
    {
        private readonly IEfRepository<Patrol> _repository;

        private readonly IMapper _mapper;

        public CreatePatrolCommandHandler(IEfRepository<Patrol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePatrolCommand request, CancellationToken cancellationToken)
        {
            var patrol = _mapper.Map<CreatePatrolCommand, Patrol>(request);
            await _repository.CreateAsync(patrol);
            await _repository.SaveChangesAsync();
            return patrol.Id;
        }
    }
}

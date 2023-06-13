using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Infrastructure;
using TN_TestTask.WebMVC.Models;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPatrolsListQueryHandler : IRequestHandler<GetPatrolsListQuery, IndexViewModel>
    {
        private readonly IEfRepository<Patrol> _repository;

        private readonly IMapper _mapper;

        public GetPatrolsListQueryHandler(IEfRepository<Patrol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IndexViewModel> Handle(GetPatrolsListQuery request, CancellationToken cancellationToken)
        {
            var patrols = await _repository.GetAll();

            var patrolsDto = patrols.AsQueryable().ProjectTo<PatrolListItemDto>(_mapper.ConfigurationProvider);                        

            if (!String.IsNullOrEmpty(request.TitleFilter))
            {
                patrolsDto = patrolsDto.Where(p => p.Title.Contains(request.TitleFilter));
            }

            switch(request.SortOrder)
            {
                case SortState.TitleDesc:
                    patrolsDto = patrolsDto.OrderByDescending(s => s.Title);
                    break;
                case SortState.StatusAsc:
                    patrolsDto = patrolsDto.OrderBy(s => s.Status);
                    break;
                case SortState.StatusDesc:
                    patrolsDto = patrolsDto.OrderByDescending(s => s.Status);
                    break;
                default:
                    patrolsDto = patrolsDto.OrderBy(s => s.Title);
                    break;
            }

            var viewModel = new IndexViewModel
            {
                SortViewModel = new SortViewModel(request.SortOrder),
                FilterViewModel = new FilterViewModel(request.TitleFilter),
                Patrols = patrolsDto
            };

            return viewModel;
        }
    }
}

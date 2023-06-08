using AutoMapper;
using TN_TestTask.Core;
using TN_TestTask.WebMVC.Application;

namespace TN_TestTask.WebMVC
{
    public class PatrolProfile : Profile
    {
        public PatrolProfile()
        {
            CreateMap<CreatePatrolCommand, Patrol>();
            CreateMap<UpdatePatrolCommand, Patrol>();
            CreateMap<Patrol, PatrolListItemDto>();
            CreateMap<Patrol, PatrolItemDto>();
        }
    }
}

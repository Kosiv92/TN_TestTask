using AutoMapper;
using System;
using TN_TestTask.Core;
using TN_TestTask.WebMVC.Application;

namespace TN_TestTask.WebMVC
{
    public class PatrolProfile : Profile
    {
        public PatrolProfile()
        {
            CreateMap<CreatePatrolCommand, Patrol>()
                .ForMember(p => p.PlaceId, 
                opt => opt.MapFrom(com => Guid.Parse(com.PlaceId)));

            CreateMap<UpdatePatrolCommand, Patrol>()
                .ForMember(p => p.PlaceId,
                opt => opt.MapFrom(com => Guid.Parse(com.PlaceId)));

            CreateMap<Patrol, PatrolListItemDto>();

            CreateMap<Patrol, PatrolItemDto>();
        }
    }
}

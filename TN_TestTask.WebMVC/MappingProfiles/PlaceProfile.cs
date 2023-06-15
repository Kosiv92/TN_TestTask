using AutoMapper;
using TN_TestTask.Core;
using TN_TestTask.WebMVC.Application;

namespace TN_TestTask.WebMVC
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<CreatePlaceCommand, Place>();
            CreateMap<Place, PlaceListItemDto>();
        }
    }
}

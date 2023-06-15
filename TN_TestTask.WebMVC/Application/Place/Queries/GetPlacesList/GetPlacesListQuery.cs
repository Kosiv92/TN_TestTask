using MediatR;
using System.Collections.Generic;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPlacesListQuery : IRequest<IEnumerable<PlaceListItemDto>>
    { }
}

using MediatR;
using TN_TestTask.WebMVC.Models;

namespace TN_TestTask.WebMVC.Application
{
    public class GetPatrolsListQuery : IRequest<IndexViewModel>
    {
        public SortState SortOrder;

        public string? TitleFilter { get; set; }
    }
}

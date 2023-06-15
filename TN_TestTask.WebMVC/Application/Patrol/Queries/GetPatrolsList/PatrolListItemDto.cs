using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class PatrolListItemDto : BaseEntity
    {        
        public string Title { get; private set; }
        public PatrolStatus Status { get; private set; }

        public Place Place { get; private set; }

    }
}

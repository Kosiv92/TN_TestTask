
namespace TN_TestTask.Core
{
    public class Patrol : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public PatrolStatus Status { get; set; }
    }        
}

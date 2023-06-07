using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure
{
    public class PatrolRepository : EfRepository<Patrol>
    {
        public PatrolRepository(PatrolDbContext context) : base(context)
        {
        }
    }
}

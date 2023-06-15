using System;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class PatrolItemDto : BaseEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public PatrolStatus Status { get; private set; }

        public Guid PlaceId { get; private set; }
    }
}

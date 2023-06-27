using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TN_TestTask.Core;

namespace TN_TestTask.WebMVC.Application
{
    public class PatrolItemDto : BaseEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public PatrolStatus Status { get; private set; }

        public Guid PlaceId { get; private set; }

        public List<SelectListItem> Places { get; set; }
    }
}

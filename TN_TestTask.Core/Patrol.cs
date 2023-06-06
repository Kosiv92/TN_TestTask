using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN_TestTask.Core
{
    public class Patrol : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateBegin { get; set; }

        public DateTimeOffset DateEnd { get; set; }

    }
}

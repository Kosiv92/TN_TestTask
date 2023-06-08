using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TN_TestTask.WebMVC.Application;

namespace TN_TestTask.WebMVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<PatrolListItemDto> Patrols { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}

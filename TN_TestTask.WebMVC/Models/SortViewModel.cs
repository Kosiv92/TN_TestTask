using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN_TestTask.WebMVC.Models
{
    public class SortViewModel
    {
        public SortState TitleSort { get; private set; }

        public SortState StatusSort { get; private set; }

        public SortState PlaceSort { get; private set; }

        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            StatusSort = sortOrder == SortState.StatusAsc ? SortState.StatusDesc : SortState.StatusAsc;
            PlaceSort = sortOrder == SortState.PlaceAsc ? SortState.PlaceDesc : SortState.PlaceAsc;
            Current = sortOrder;
        }
    }

    public enum SortState
    {
        TitleAsc,
        TitleDesc,
        StatusAsc,
        StatusDesc,
        PlaceAsc,
        PlaceDesc
    }
}

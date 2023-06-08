
namespace TN_TestTask.WebMVC.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(string title)
        {
            SelectedTitle = title;
        }
        public object SelectedTitle { get; private set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TN_TestTask.Core
{
    public enum PatrolStatus
    {
        [Display(Name="Создан")]
        Created,
        [Display(Name = "В работе")]
        Started,
        [Display(Name = "Завершен")]
        Finished,
        [Display(Name = "Отменен")]
        Canceled
    }
}

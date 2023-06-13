using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TN_TestTask.Core
{
    public enum PatrolStatus
    {
        [Description("Создан")]
        [Display(Name="Создан")]
        Created,
        [Description("В работе")]
        [Display(Name = "В работе")]
        Started,
        [Description("Завершен")]
        [Display(Name = "Завершен")]
        Finished,
        [Description("Отменен")]
        [Display(Name = "Отменен")]
        Canceled
    }

    public static class EnumMemberExtensions
    {
        public static string GetName(this Enum enumElement)
        {
            Type type = enumElement.GetType();
            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }
}

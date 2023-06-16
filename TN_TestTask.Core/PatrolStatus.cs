using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

    public static class EnumMemberExtensions
    {
        public static string GetName(this Enum enumElement)
        {
            Type type = enumElement.GetType();
            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DisplayAttribute)attrs[0]).GetName();
            }

            return enumElement.ToString();
        }
    }
}

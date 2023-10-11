using System.ComponentModel;

namespace Finansy.Core.Extensions;

public static class EnumExtensions
{
    public static string ToDescriptionString(this Enum val)
    {
        var attributes = (DescriptionAttribute[])val
            .GetType()
            .GetField(val.ToString())
            ?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
    
    public static string ToPortugues(this DayOfWeek val)
    {
        return val switch
        {
            DayOfWeek.Monday => "Segunda",
            DayOfWeek.Tuesday => "Terça",
            DayOfWeek.Wednesday => "Quarta",
            DayOfWeek.Thursday => "Quinta",
            DayOfWeek.Friday => "Sexta",
            DayOfWeek.Saturday => "Sábado",
            DayOfWeek.Sunday => "Domingo",
            _ => throw new ArgumentOutOfRangeException(nameof(val), val, null)
        };
    }
}
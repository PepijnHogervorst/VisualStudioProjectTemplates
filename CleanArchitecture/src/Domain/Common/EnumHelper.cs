using System.ComponentModel;
using System.Globalization;

namespace Domain.Common;
/// <summary>
/// Enum helper methods, use to get ValueDescription from enum value
/// </summary>
public static class EnumHelper
{
    public static string Description(this Enum value)
    {
        var attributes = value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes == null) return string.Empty;
        if (attributes.Any() && attributes.First() is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        var ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase(ti.ToLower(value.ToString().Replace("_", " ")));
    }

    public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
    {
        if (!t.IsEnum)
            throw new ArgumentException($"{nameof(t)} must be an enum type");

        return Enum.GetValues(t).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
    }
}

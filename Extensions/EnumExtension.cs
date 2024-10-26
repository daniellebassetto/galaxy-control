using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GalaxyControl.Extensions;

public static class EnumExtension
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        var displayAttribute = enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<DisplayAttribute>();

        return displayAttribute == null ? enumValue.ToString() : displayAttribute.Name;
    }
}
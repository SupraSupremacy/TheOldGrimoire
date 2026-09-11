using System.Globalization;
using Microsoft.Maui.Controls;

namespace TheOldGrimoire.Helpers;

public class HexColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string hex && !string.IsNullOrWhiteSpace(hex) && Color.TryParse(hex, out var color))
        {
            return color;
        }
        return Colors.Gray;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value as Color)?.ToArgbHex();
    }
}
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TheOldGrimoire.Helpers;

public class BoolToOpacityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool active = value is bool b && b;
        if (parameter?.ToString() == "invert")
            active = !active;
        return active ? 1.0 : 0.35;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

using System.Globalization;
using Microsoft.Maui.Controls;

namespace TheOldGrimoire.Converters;

public class IsNullOrEmptyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool isEmpty = string.IsNullOrEmpty(value?.ToString());
        if (parameter?.ToString() == "true")
        {
            return !isEmpty;
        }
        return isEmpty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
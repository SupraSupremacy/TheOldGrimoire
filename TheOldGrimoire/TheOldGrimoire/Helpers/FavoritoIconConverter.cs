using System.Globalization;
using Microsoft.Maui.Controls;

namespace TheOldGrimoire.Helpers;

public class FavoritoIconConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value is bool esFavorito && esFavorito) ? "⭐" : "☆";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
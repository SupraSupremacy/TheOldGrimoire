using System.Globalization;
using Microsoft.Maui.Controls;

namespace TheOldGrimoire.Helpers;

// Convierte el estado "voto positivo activo" (bool) a un color para la flecha ▲
public class VotoColorConverter : IValueConverter
{
    public static readonly Color Activo = Color.FromArgb("#ff6b35");
    public static readonly Color Inactivo = Color.FromArgb("#8a7a7a");

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? Activo : Inactivo;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

// Convierte el estado "voto negativo activo" (bool) a un color para la flecha ▼
public class VotoNegativoColorConverter : IValueConverter
{
    public static readonly Color Activo = Color.FromArgb("#4da6ff");
    public static readonly Color Inactivo = Color.FromArgb("#8a7a7a");

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true ? Activo : Inactivo;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
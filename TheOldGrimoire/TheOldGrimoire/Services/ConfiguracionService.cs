using System;
using Microsoft.Maui.Storage;

namespace TheOldGrimoire.Services;

public class ConfiguracionService
{
    private const string CLAVE_TEMA = "tema_oscuro";
    private const string CLAVE_FUENTE = "tamano_fuente";
    private const string CLAVE_TIPO_FUENTE = "tipo_fuente";
    private const string CLAVE_COLOR_ACENTO = "color_acento";

    private static readonly Lazy<ConfiguracionService> _instance =
        new(() => new ConfiguracionService());

    public static ConfiguracionService Instance => _instance.Value;

    private ConfiguracionService()
    {
    }

    // Tema Oscuro/Claro
    public bool TemaOscuro
    {
        get => Preferences.Get(CLAVE_TEMA, true); // Por defecto: oscuro
        set => Preferences.Set(CLAVE_TEMA, value);
    }

    // Tamaño de fuente (1 = Pequeño, 2 = Normal, 3 = Grande, 4 = Muy Grande)
    public int TamanoFuente
    {
        get => Preferences.Get(CLAVE_FUENTE, 2);
        set => Preferences.Set(CLAVE_FUENTE, value);
    }

    // Tipo de fuente
    public string TipoFuente
    {
        get => Preferences.Get(CLAVE_TIPO_FUENTE, "Times New Roman");
        set => Preferences.Set(CLAVE_TIPO_FUENTE, value);
    }

    // Color de acento (para detalles como títulos, botones, etc.)
    public string ColorAcento
    {
        get => Preferences.Get(CLAVE_COLOR_ACENTO, "#d4af37");
        set => Preferences.Set(CLAVE_COLOR_ACENTO, value);
    }

    // Obtener la fuente según tamaño seleccionado
    public double ObtenerTamanoFuente()
    {
        return TamanoFuente switch
        {
            1 => 12,    // Pequeño
            2 => 16,    // Normal
            3 => 20,    // Grande
            4 => 24,    // Muy Grande
            _ => 16
        };
    }

    // Lista de colores de acento disponibles
    public List<string> ColoresAcentoDisponibles => new()
    {
        "#d4af37", // Dorado (default)
        "#8b0000", // Rojo sangre
        "#4a0080", // Púrpura oscuro
        "#006400", // Verde oscuro
        "#2f4f4f", // Gris pizarra
        "#8b4513"  // Marrón
    };

    // Lista de tipos de fuente disponibles
    public List<string> FuentesDisponibles => new()
    {
        "Times New Roman",
        "Georgia",
        "Garamond",
        "Arial",
        "Verdana",
        "Courier New"
    };
}
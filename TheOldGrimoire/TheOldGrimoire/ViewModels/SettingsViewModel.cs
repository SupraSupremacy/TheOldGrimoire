using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Storage;

namespace TheOldGrimoire.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private readonly ConfiguracionService _configuracionService;

    [ObservableProperty]
    public partial bool TemaOscuro { get; set; }

    [ObservableProperty]
    public partial int TamanoFuenteSeleccionado { get; set; }

    [ObservableProperty]
    public partial string TipoFuenteSeleccionado { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ColorAcentoSeleccionado { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Mensaje { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool MensajeVisible { get; set; }

    [ObservableProperty]
    public partial bool MensajeEsExito { get; set; }

    public ObservableCollection<string> OpcionesFuente { get; }
    public ObservableCollection<string> OpcionesAcento { get; }
    public ObservableCollection<string> OpcionesTamanoFuente { get; }

    public ICommand CerrarSesionCommand { get; }
    public ICommand GuardarConfiguracionCommand { get; }
    public ICommand VerAcercaDeCommand { get; }

    public SettingsViewModel()
    {
        _configuracionService = ConfiguracionService.Instance;

        // Cargar configuraciones
        TamanoFuenteSeleccionado = _configuracionService.TamanoFuente;
        ColorAcentoSeleccionado = _configuracionService.ColorAcento;
        TipoFuenteSeleccionado = _configuracionService.TipoFuente;
        TemaOscuro = _configuracionService.TemaOscuro;

        // Opciones para los pickers
        OpcionesFuente = new ObservableCollection<string>(_configuracionService.FuentesDisponibles);
        OpcionesAcento = new ObservableCollection<string>(_configuracionService.ColoresAcentoDisponibles);
        OpcionesTamanoFuente = new ObservableCollection<string> { "Pequeño", "Normal", "Grande", "Muy Grande" };

        // Comandos
        CerrarSesionCommand = new RelayCommand(CerrarSesion);
        GuardarConfiguracionCommand = new RelayCommand(GuardarConfiguracion);
        VerAcercaDeCommand = new RelayCommand(VerAcercaDe);
    }

    // Cambiar el tema en tiempo real
    partial void OnTemaOscuroChanged(bool value)
    {
        AplicarTema(value);
    }

    private void AplicarTema(bool oscuro)
    {
        // Aplicar tema en toda la app
        _configuracionService.TemaOscuro = oscuro;
        AplicarCambiosGlobales();
    }

    private async void GuardarConfiguracion()
    {
        try
        {
            _configuracionService.TemaOscuro = TemaOscuro;
            _configuracionService.TamanoFuente = TamanoFuenteSeleccionado;
            _configuracionService.TipoFuente = TipoFuenteSeleccionado;
            _configuracionService.ColorAcento = ColorAcentoSeleccionado;

            await MostrarMensaje("✅ Configuración guardada correctamente", true);

            // Aquí notificar a otras páginas que cambió la config
            // Podemos usar MessagingCenter o un evento global
            AplicarCambiosGlobales();
        }
        catch (Exception ex)
        {
            await MostrarMensaje($"❌ Error al guardar: {ex.Message}", false);
        }
    }

    private void AplicarCambiosGlobales()
    {
        if (Application.Current is not App app)
            return;

        // Aplicar tema oscuro/claro en toda la app
        app.AplicarTema(TemaOscuro);

        // Aplicar color de acento (títulos, botones, etc.)
        if (!string.IsNullOrEmpty(ColorAcentoSeleccionado))
        {
            app.Resources["Primary"] = Color.FromArgb(ColorAcentoSeleccionado);
        }

        // Aplicar tipo de fuente global
        if (!string.IsNullOrEmpty(TipoFuenteSeleccionado))
        {
            app.Resources["FontFamily"] = TipoFuenteSeleccionado;
        }
    }

    private async void CerrarSesion()
    {
        var confirmar = await Shell.Current.DisplayAlertAsync(
            "Cerrar Sesión",
            "¿Estás seguro que querés cerrar sesión?",
            "Sí, cerrar",
            "Cancelar"
        );

        if (confirmar)
        {
            // Limpiar datos de sesión
            Preferences.Clear();

            // Redirigir al login (cuando lo tengamos)
            // Por ahora, mostrar mensaje y resetear config
            await MostrarMensaje("👋 Sesión cerrada correctamente", true);

            // Resetear a configuración por defecto
            TemaOscuro = true;
            TamanoFuenteSeleccionado = 2;
            TipoFuenteSeleccionado = "Times New Roman";
            ColorAcentoSeleccionado = "#d4af37";
            GuardarConfiguracion();
        }
    }

    private async void VerAcercaDe()
    {
        await Shell.Current.DisplayAlertAsync(
            "📖 The Old Grimoire",
            "Versión 1.0.0\n\n" +
            "Una aplicación para amantes del terror.\n\n" +
            "Desarrollado con ❤️ por:\n" +
            "• Ángel De Jesús Alemán Meléndez\n" +
            "• Katia Nicole Asunsión Merlos\n" +
            "• Kevin Ernesto Corpeño Castillo\n" +
            "• Daniel Elías Rodríguez Hernández",
            "Cerrar"
        );
    }

    private async Task MostrarMensaje(string texto, bool esExito)
    {
        Mensaje = texto;
        MensajeEsExito = esExito;
        MensajeVisible = true;
        await Task.Delay(3000);
        MensajeVisible = false;
    }
}
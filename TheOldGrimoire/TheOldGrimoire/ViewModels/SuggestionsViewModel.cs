using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;
using System.Windows.Input;

namespace TheOldGrimoire.ViewModels;

public partial class SuggestionsViewModel : ObservableObject
{
    private readonly ComunidadService _comunidadService;

    [ObservableProperty]
    public partial string NombreUsuario { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TituloHistoria { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Autor { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string GeneroSeleccionado { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Descripcion { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Mensaje { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool MensajeVisible { get; set; }

    [ObservableProperty]
    public partial bool MensajeEsExito { get; set; } = true;

    [ObservableProperty]
    public partial bool EstaOcupado { get; set; }

    public ICommand GuardarCommand { get; }
    public ICommand LimpiarCommand { get; }

    public SuggestionsViewModel()
    {
        _comunidadService = new ComunidadService();
        GuardarCommand = new RelayCommand(GuardarSugerencia);
        LimpiarCommand = new RelayCommand(LimpiarFormulario);
    }

    private async void GuardarSugerencia()
    {
        try
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(NombreUsuario))
            {
                await MostrarMensaje("⚠️ Por favor, ingresá tu nombre.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(TituloHistoria))
            {
                await MostrarMensaje("⚠️ Por favor, ingresá el título de la historia.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(GeneroSeleccionado))
            {
                await MostrarMensaje("⚠️ Por favor, seleccioná un género.", false);
                return;
            }

            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                await MostrarMensaje("⚠️ Por favor, contanos de qué trata la historia.", false);
                return;
            }

            EstaOcupado = true;

            // Guardar la sugerencia en el servicio compartido de la comunidad
            await Task.Run(() => _comunidadService.AgregarSugerencia(new Sugerencia
            {
                NombreUsuario = NombreUsuario,
                Titulo = TituloHistoria,
                Autor = string.IsNullOrWhiteSpace(Autor) ? "Anónimo" : Autor,
                Genero = GeneroSeleccionado,
                Descripcion = Descripcion
            }));

            await MostrarMensaje($"✅ ¡Gracias {NombreUsuario}! Tu sugerencia fue publicada en la Comunidad.", true);

            // Limpiar formulario después de guardar
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            await MostrarMensaje($"❌ Error al guardar: {ex.Message}", false);
        }
        finally
        {
            EstaOcupado = false;
        }
    }

    private void LimpiarFormulario()
    {
        NombreUsuario = string.Empty;
        TituloHistoria = string.Empty;
        Autor = string.Empty;
        GeneroSeleccionado = string.Empty;
        Descripcion = string.Empty;
        Mensaje = string.Empty;
        MensajeVisible = false;
    }

    private async Task MostrarMensaje(string texto, bool esExito)
    {
        Mensaje = texto;
        MensajeEsExito = esExito;
        MensajeVisible = true;

        await Task.Delay(5000); // Mostrar mensaje por 5 segundos
        MensajeVisible = false;
    }
}
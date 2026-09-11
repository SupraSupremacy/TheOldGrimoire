using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;
using TheOldGrimoire.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TheOldGrimoire.ViewModels;

public partial class ComunidadViewModel : ObservableObject
{
    private readonly ComunidadService _comunidadService;

    [ObservableProperty]
    public partial ObservableCollection<Sugerencia> Sugerencias { get; set; } = new();

    [ObservableProperty]
    public partial bool EstaVacio { get; set; } = true;

    [ObservableProperty]
    public partial int FiltroSeleccionado { get; set; }

    public ObservableCollection<string> OpcionesFiltro { get; }

    private static readonly OrdenSugerencias[] OrdenesPorIndice =
    {
        OrdenSugerencias.MayorVotos,
        OrdenSugerencias.MenorVotos,
        OrdenSugerencias.MasRecientes,
        OrdenSugerencias.MasAntiguas
    };

    public ICommand VotarArribaCommand { get; }
    public ICommand VotarAbajoCommand { get; }
    public ICommand ComentarCommand { get; }
    public ICommand VerDetalleCommand { get; }
    public ICommand IrASugerenciasCommand { get; }

    public ComunidadViewModel()
    {
        _comunidadService = new ComunidadService();
        OpcionesFiltro = new ObservableCollection<string>
        {
            "🔥 Más votadas",
            "📉 Menos votadas",
            "🕒 Más recientes",
            "📜 Más antiguas"
        };
        VotarArribaCommand = new RelayCommand<Sugerencia?>(s =>
        {
            if (s != null)
            {
                _comunidadService.VotarArriba(s);
                Refrescar();
            }
        });
        VotarAbajoCommand = new RelayCommand<Sugerencia?>(s =>
        {
            if (s != null)
            {
                _comunidadService.VotarAbajo(s);
                Refrescar();
            }
        });
        ComentarCommand = new RelayCommand<Sugerencia?>(Comentar);
        VerDetalleCommand = new RelayCommand<Sugerencia?>(VerDetalle);
        IrASugerenciasCommand = new AsyncRelayCommand(IrASugerencias);
        Refrescar();
    }

    partial void OnFiltroSeleccionadoChanged(int value)
    {
        Refrescar();
    }

    public void Refrescar()
    {
        var orden = OrdenesPorIndice[
            Math.Clamp(FiltroSeleccionado, 0, OrdenesPorIndice.Length - 1)];
        Sugerencias = _comunidadService.ObtenerSugerencias(orden);
        EstaVacio = Sugerencias.Count == 0;
    }

    private async void Comentar(Sugerencia? sugerencia)
    {
        if (sugerencia == null)
        {
            return;
        }

        var texto = await Shell.Current.DisplayPromptAsync(
            "💬 Comentar",
            "Escribí tu comentario sobre la sugerencia:",
            "Enviar",
            "Cancelar",
            placeholder: "Tu comentario...");

        if (!string.IsNullOrWhiteSpace(texto))
        {
            _comunidadService.AgregarComentario(sugerencia.Id, new Comentario
            {
                NombreUsuario = sugerencia.NombreUsuario,
                Texto = texto.Trim()
            });
        }
    }

    private async void VerDetalle(Sugerencia? sugerencia)
    {
        if (sugerencia == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(Views.SugerenciaDetailPage),
            new Dictionary<string, object> { { "Sugerencia", sugerencia } });
    }

    private async Task IrASugerencias()
    {
        await Shell.Current.GoToAsync("//SuggestionsPage");
    }
}
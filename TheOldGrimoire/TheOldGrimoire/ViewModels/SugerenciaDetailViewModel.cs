using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;
using System.Windows.Input;

namespace TheOldGrimoire.ViewModels;

[QueryProperty(nameof(Sugerencia), "Sugerencia")]
public partial class SugerenciaDetailViewModel : ObservableObject
{
    private readonly ComunidadService _comunidadService;

    [ObservableProperty]
    public partial Sugerencia? Sugerencia { get; set; }

    [ObservableProperty]
    public partial string NuevoComentario { get; set; } = string.Empty;

    public ICommand VotarArribaCommand { get; }
    public ICommand VotarAbajoCommand { get; }
    public ICommand EnviarComentarioCommand { get; }

    public SugerenciaDetailViewModel()
    {
        _comunidadService = new ComunidadService();
        VotarArribaCommand = new RelayCommand(VotarArriba);
        VotarAbajoCommand = new RelayCommand(VotarAbajo);
        EnviarComentarioCommand = new RelayCommand(EnviarComentario);
    }

    private void VotarArriba()
    {
        if (Sugerencia != null) _comunidadService.VotarArriba(Sugerencia);
    }

    private void VotarAbajo()
    {
        if (Sugerencia != null) _comunidadService.VotarAbajo(Sugerencia);
    }

    private void EnviarComentario()
    {
        if (Sugerencia == null || string.IsNullOrWhiteSpace(NuevoComentario))
        {
            return;
        }

        _comunidadService.AgregarComentario(Sugerencia.Id, new Comentario
        {
            NombreUsuario = Sugerencia.NombreUsuario,
            Texto = NuevoComentario.Trim()
        });

        NuevoComentario = string.Empty;
    }
}
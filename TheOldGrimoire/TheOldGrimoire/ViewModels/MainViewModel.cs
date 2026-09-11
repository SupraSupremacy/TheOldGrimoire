using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TheOldGrimoire.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly HistoriaService _historiaService;
    private readonly FavoritosService _favoritosService;

    [ObservableProperty]
    public partial ObservableCollection<Historia> Historias { get; set; } = new();

    [ObservableProperty]
    public partial bool IsRefreshing { get; set; }

    public ICommand ToggleFavoritoCommand { get; }

    public MainViewModel()
    {
        _historiaService = new HistoriaService();
        _favoritosService = FavoritosService.Instance;
        ToggleFavoritoCommand = new RelayCommand<Historia?>(ToggleFavorito);
        CargarHistorias();
    }

    private void CargarHistorias()
    {
        Historias = _favoritosService.ObtenerTodasLasHistorias();
    }

    private void ToggleFavorito(Historia? historia)
    {
        if (historia == null) return;

        _favoritosService.AlternarFavorito(historia);

        // Notificar cambio en la UI
        var index = Historias.IndexOf(historia);
        if (index >= 0)
        {
            Historias[index] = historia; // Actualiza la UI
        }
    }

    // Refresca el estado de favoritos cuando se vuelve a la página
    public void Refrescar()
    {
        var historias = _favoritosService.ObtenerTodasLasHistorias();
        Historias = historias;
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TheOldGrimoire.ViewModels;

public partial class FavoritesViewModel : ObservableObject
{
    private readonly FavoritosService _favoritosService;

    [ObservableProperty]
    public partial ObservableCollection<Historia> Favoritos { get; set; } = new();

    [ObservableProperty]
    public partial bool HayFavoritos { get; set; }

    public ICommand IrABibliotecaCommand { get; }
    public ICommand ToggleFavoritoCommand { get; }

    public FavoritesViewModel()
    {
        _favoritosService = FavoritosService.Instance;
        IrABibliotecaCommand = new RelayCommand(IrABiblioteca);
        ToggleFavoritoCommand = new RelayCommand<Historia?>(ToggleFavorito);
        CargarFavoritos();
    }

    private void ToggleFavorito(Historia? historia)
    {
        if (historia == null) return;

        _favoritosService.AlternarFavorito(historia);
        Refrescar();
    }

    private void CargarFavoritos()
    {
        Favoritos = _favoritosService.ObtenerFavoritos();
        HayFavoritos = Favoritos.Any();
    }

    private async void IrABiblioteca()
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    // Método para refrescar la lista (cuando se vuelve a la página)
    public void Refrescar()
    {
        CargarFavoritos();
    }
}
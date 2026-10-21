using TheOldGrimoire.Models;
using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class FavoritesPage : ContentPage
{
    private FavoritesViewModel _viewModel;

    public FavoritesPage()
    {
        InitializeComponent();
        _viewModel = new FavoritesViewModel();
        BindingContext = _viewModel;

        FavoritosCollection.SelectionChanged += OnFavoritoSeleccionado;
    }

    private async void OnFavoritoSeleccionado(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Historia historia)
        {
            var ruta = historia.TienePdf ? nameof(PdfViewerPage) : nameof(DetailPage);

            await Shell.Current.GoToAsync(ruta, new Dictionary<string, object>
            {
                { "Historia", historia }
            });

            FavoritosCollection.SelectedItem = null;
        }
    }

    // Refrescar al volver a la página
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Refrescar();
    }
}
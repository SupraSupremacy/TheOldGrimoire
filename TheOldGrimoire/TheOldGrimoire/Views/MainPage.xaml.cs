using TheOldGrimoire.Models;
using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new MainViewModel();
        BindingContext = _viewModel;

        // Suscribirse al evento de selección
        HistoriasCollection.SelectionChanged += OnHistoriaSeleccionada;
    }

    // Refrescar el estado de favoritos al volver a la página
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Refrescar();
    }

    private async void OnHistoriaSeleccionada(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Historia historia)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Historia", historia }
            };

            await Shell.Current.GoToAsync(nameof(DetailPage), navigationParameter);

            // Limpiar selección
            HistoriasCollection.SelectedItem = null;
        }
    }
}
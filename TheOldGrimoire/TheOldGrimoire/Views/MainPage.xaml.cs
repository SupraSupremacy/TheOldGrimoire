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

    private async void OnCoverTapped(object? sender, TappedEventArgs e)
    {
        if ((sender as BindableObject)?.BindingContext is Historia historia)
        {
            await AbrirHistoriaAsync(historia);
        }
    }

    private async void OnHistoriaSeleccionada(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Historia historia)
        {
            await AbrirHistoriaAsync(historia);

            // Limpiar selección
            HistoriasCollection.SelectedItem = null;
        }
    }

    private static async Task AbrirHistoriaAsync(Historia historia)
    {
        var ruta = historia.TienePdf ? nameof(PdfViewerPage) : nameof(DetailPage);

        await Shell.Current.GoToAsync(ruta, new Dictionary<string, object>
        {
            { "Historia", historia }
        });
    }
}
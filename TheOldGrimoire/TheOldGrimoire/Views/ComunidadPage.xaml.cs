using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class ComunidadPage : ContentPage
{
    private readonly ComunidadViewModel _viewModel;

    public ComunidadPage()
    {
        InitializeComponent();
        _viewModel = new ComunidadViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Refrescar();
    }
}
using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class SugerenciaDetailPage : ContentPage
{
    private readonly SugerenciaDetailViewModel _viewModel;

    public SugerenciaDetailPage()
    {
        InitializeComponent();
        _viewModel = new SugerenciaDetailViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (_viewModel.Sugerencia != null)
        {
            Title = _viewModel.Sugerencia.Titulo.Length > 25 ?
                    _viewModel.Sugerencia.Titulo.Substring(0, 25) + "..." :
                    _viewModel.Sugerencia.Titulo;
        }
    }
}
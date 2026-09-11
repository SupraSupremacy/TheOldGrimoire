using TheOldGrimoire.Models;
using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage()
    {
        InitializeComponent();
        BindingContext = new DetailViewModel();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (BindingContext is DetailViewModel vm && vm.Historia != null)
        {
            Title = vm.Historia.Titulo.Length > 20 ?
                    vm.Historia.Titulo.Substring(0, 20) + "..." :
                    vm.Historia.Titulo;
        }
    }
}
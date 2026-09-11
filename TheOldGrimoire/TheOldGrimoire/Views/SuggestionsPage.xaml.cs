using TheOldGrimoire.ViewModels;

namespace TheOldGrimoire.Views;

public partial class SuggestionsPage : ContentPage
{
    public SuggestionsPage()
    {
        InitializeComponent();
        BindingContext = new SuggestionsViewModel();
    }
}
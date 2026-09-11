using TheOldGrimoire.Views;

namespace TheOldGrimoire;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(SugerenciaDetailPage), typeof(SugerenciaDetailPage));
    }
}
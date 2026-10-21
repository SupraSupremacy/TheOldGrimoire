using TheOldGrimoire.Views;

namespace TheOldGrimoire;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(PdfViewerPage), typeof(PdfViewerPage));
        Routing.RegisterRoute(nameof(SugerenciaDetailPage), typeof(SugerenciaDetailPage));
    }
}
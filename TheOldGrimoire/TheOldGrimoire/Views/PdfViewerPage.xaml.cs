using Microsoft.Maui.Storage;
using TheOldGrimoire.Models;

namespace TheOldGrimoire.Views;

[QueryProperty(nameof(Historia), "Historia")]
public partial class PdfViewerPage : ContentPage
{
    private Historia? _historia;
    private bool _webReady;
    private bool _pdfRequested;

    public Historia? Historia
    {
        get => _historia;
        set
        {
            _historia = value;
            Title = value is null
                ? "Lector"
                : value.Titulo.Length > 24
                    ? value.Titulo.Substring(0, 24) + "..."
                    : value.Titulo;
        }
    }

    public PdfViewerPage()
    {
        InitializeComponent();
        PdfWebView.RawMessageReceived += OnWebMessageReceived;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await IntentarCargarPdfAsync();
    }

    private void OnWebMessageReceived(object? sender, HybridWebViewRawMessageReceivedEventArgs e)
    {
        if (e.Message != "pdf-ready")
            return;

        _webReady = true;
        _ = IntentarCargarPdfAsync();
    }

    private async Task IntentarCargarPdfAsync()
    {
        if (_pdfRequested || !_webReady || Historia is null)
            return;

        if (string.IsNullOrWhiteSpace(Historia.PdfFileName))
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            await Shell.Current.DisplayAlertAsync(
                "PDF no disponible",
                "Esta historia no tiene un archivo PDF asociado.",
                "OK");
            return;
        }

        var assetPath = $"wwwroot/histories/{Historia.PdfFileName}";
        if (!await FileSystem.AppPackageFileExistsAsync(assetPath))
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            await Shell.Current.DisplayAlertAsync(
                "PDF no encontrado",
                "No se pudo encontrar el archivo de esta historia.",
                "OK");
            return;
        }

        _pdfRequested = true;

        try
        {
            var pdfPath = $"/histories/{Historia.PdfFileName}";
            await PdfWebView.EvaluateJavaScriptAsync($"loadPdf('{pdfPath}')");
        }
        catch
        {
            _pdfRequested = false;
            await Shell.Current.DisplayAlertAsync(
                "Error al abrir el PDF",
                "No se pudo iniciar el lector. Inténtalo de nuevo.",
                "OK");
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }
    }
}

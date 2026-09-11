using TemaOscuro = TheOldGrimoire.Resources.Styles.Colors;
using TemaClaro = TheOldGrimoire.Resources.Styles.ColorsLight;
using Microsoft.Maui.Storage;

namespace TheOldGrimoire;

public partial class App : Application
{
    private const string ModoOscuroKey = "tema_oscuro";
    private const string TemaKey = "Primary";

    private ResourceDictionary? _temaActual;

    public App()
    {
        InitializeComponent();
        _temaActual = Resources.MergedDictionaries.FirstOrDefault(d => d.ContainsKey(TemaKey));
        AplicarTema(Preferences.Get(ModoOscuroKey, true));
        AplicarConfiguracionGuardada();
    }

    // Aplica el color de acento y el tipo de fuente guardados al iniciar
    private void AplicarConfiguracionGuardada()
    {
        var colorAcento = Preferences.Get("color_acento", "#d4af37");
        if (!string.IsNullOrEmpty(colorAcento) && Color.TryParse(colorAcento, out var color))
        {
            Resources["Primary"] = color;
        }

        var tipoFuente = Preferences.Get("tipo_fuente", "Times New Roman");
        if (!string.IsNullOrEmpty(tipoFuente))
        {
            Resources["FontFamily"] = tipoFuente;
        }
    }

    public void AplicarTema(bool oscuro)
    {
        UserAppTheme = oscuro ? AppTheme.Dark : AppTheme.Light;

        var tipoNuevoTema = oscuro ? typeof(TemaOscuro) : typeof(TemaClaro);

        if (_temaActual?.GetType() == tipoNuevoTema)
        {
            return;
        }

        if (_temaActual != null)
        {
            Resources.MergedDictionaries.Remove(_temaActual);
        }

        _temaActual = oscuro ? new TemaOscuro() : new TemaClaro();

        Resources.MergedDictionaries.Add(_temaActual);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());
#if WINDOWS
        window.HandlerChanged += OnWindowsHandlerChanged;
#endif
        return window;
    }

#if WINDOWS
    private void OnWindowsHandlerChanged(object? sender, EventArgs e)
    {
        if (sender is Window window && window.Handler?.PlatformView is Microsoft.UI.Xaml.Window nativeWindow)
        {
            var hwnd = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow));
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(hwnd);

            if (appWindow.TitleBar is not null)
            {
                var bg = Microsoft.UI.ColorHelper.FromArgb(255, 0x1a, 0x1a, 0x1a);
                var fg = Microsoft.UI.ColorHelper.FromArgb(255, 0xf0, 0xe6, 0xd3);
                var hover = Microsoft.UI.ColorHelper.FromArgb(255, 0x2d, 0x2d, 0x2d);

                appWindow.TitleBar.BackgroundColor = bg;
                appWindow.TitleBar.ForegroundColor = fg;
                appWindow.TitleBar.ButtonBackgroundColor = bg;
                appWindow.TitleBar.ButtonForegroundColor = fg;
                appWindow.TitleBar.ButtonHoverBackgroundColor = hover;
                appWindow.TitleBar.ButtonHoverForegroundColor = fg;
                appWindow.TitleBar.ButtonPressedBackgroundColor = hover;
                appWindow.TitleBar.ButtonPressedForegroundColor = fg;
            }
        }
    }
#endif
}
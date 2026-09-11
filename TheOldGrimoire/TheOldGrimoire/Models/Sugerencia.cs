using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TheOldGrimoire.Models;

public partial class Sugerencia : ObservableObject
{
    [ObservableProperty]
    public partial int Id { get; set; }

    [ObservableProperty]
    public partial string NombreUsuario { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Titulo { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Autor { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Genero { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Descripcion { get; set; } = string.Empty;

    [ObservableProperty]
    public partial DateTime FechaPublicacion { get; set; }

    [ObservableProperty]
    public partial int VotosNetos { get; set; }

    [ObservableProperty]
    public partial bool UsuarioVotoArriba { get; set; }

    [ObservableProperty]
    public partial bool UsuarioVotoAbajo { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Comentario> Comentarios { get; set; } = new();

    public int TotalComentarios => Comentarios?.Count ?? 0;

    public string TiempoRelativo => CalcularTiempoRelativo();

    partial void OnFechaPublicacionChanged(DateTime value)
    {
        OnPropertyChanged(nameof(TiempoRelativo));
    }

    partial void OnComentariosChanged(ObservableCollection<Comentario> value)
    {
        OnPropertyChanged(nameof(TotalComentarios));
    }

    // Notificar a la UI cuando cambia la cantidad de comentarios
    public void NotificarComentariosCambiados()
    {
        OnPropertyChanged(nameof(TotalComentarios));
    }

    private static readonly string[] Meses =
    {
        "enero", "febrero", "marzo", "abril", "mayo", "junio",
        "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"
    };

    private string CalcularTiempoRelativo()
    {
        var diferencia = DateTime.Now - FechaPublicacion;

        if (diferencia < TimeSpan.Zero || diferencia.TotalMinutes < 1)
        {
            return "hace un momento";
        }
        if (diferencia.TotalHours < 1)
        {
            var minutos = Math.Max(1, (int)diferencia.TotalMinutes);
            return minutos == 1 ? "hace 1 minuto" : $"hace {minutos} minutos";
        }
        if (diferencia.TotalDays < 1)
        {
            var horas = (int)diferencia.TotalHours;
            return horas == 1 ? "hace 1 hora" : $"hace {horas} horas";
        }
        if (diferencia.TotalDays < 7)
        {
            var dias = (int)diferencia.TotalDays;
            return dias == 1 ? "hace 1 día" : $"hace {dias} días";
        }

        return $"{FechaPublicacion.Day} de {Meses[FechaPublicacion.Month - 1]} de {FechaPublicacion.Year}";
    }
}
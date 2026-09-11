namespace TheOldGrimoire.Models;

public class Comentario
{
    public int Id { get; set; }
    public int SugerenciaId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;
    public DateTime FechaPublicacion { get; set; }

    public string TiempoRelativo => CalcularTiempoRelativo();

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
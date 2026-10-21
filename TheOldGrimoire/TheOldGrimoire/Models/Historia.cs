using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheOldGrimoire.Models;

public class Historia : INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Sinopsis { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public string Etiqueta { get; set; } = string.Empty;
    public string ImagenUrl { get; set; } = string.Empty;
    public string PdfFileName { get; set; } = string.Empty;

    public bool TienePdf => !string.IsNullOrWhiteSpace(PdfFileName);

    private bool _esFavorito;
    public bool EsFavorito
    {
        get => _esFavorito;
        set { _esFavorito = value; OnPropertyChanged(); }
    }

    public string PortadaUrl
    {
        get
        {
            if (string.IsNullOrEmpty(ImagenUrl))
                return string.Empty;

            var nameWithoutExt = Path.GetFileNameWithoutExtension(ImagenUrl);
            var ext = Path.GetExtension(ImagenUrl);
            return $"portada_{nameWithoutExt}{ext}";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

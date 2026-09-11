using TheOldGrimoire.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheOldGrimoire.Services;

public class FavoritosService
{
    private readonly HistoriaService _historiaService;
    private ObservableCollection<Historia> _favoritos;

    private static readonly Lazy<FavoritosService> _instance =
        new Lazy<FavoritosService>(() => new FavoritosService());

    public static FavoritosService Instance => _instance.Value;

    private FavoritosService()
    {
        _historiaService = new HistoriaService();
        _favoritos = new ObservableCollection<Historia>();
    }

    // Obtener todas las historias (incluye favoritos)
    public ObservableCollection<Historia> ObtenerTodasLasHistorias()
    {
        var historias = _historiaService.ObtenerHistorias();

        // Cargar favoritos guardados (simulado)
        foreach (var historia in historias)
        {
            // En un futuro, esto vendría de SQLite
            historia.EsFavorito = _favoritos.Any(f => f.Id == historia.Id);
        }

        return historias;
    }

    // Alternar estado de favorito
    public void AlternarFavorito(Historia historia)
    {
        historia.EsFavorito = !historia.EsFavorito;

        if (historia.EsFavorito)
        {
            // Agregar a favoritos si no existe
            if (!_favoritos.Any(f => f.Id == historia.Id))
            {
                _favoritos.Add(historia);
            }
        }
        else
        {
            // Remover de favoritos
            var favorito = _favoritos.FirstOrDefault(f => f.Id == historia.Id);
            if (favorito != null)
            {
                _favoritos.Remove(favorito);
            }
        }
    }

    // Obtener solo favoritos
    public ObservableCollection<Historia> ObtenerFavoritos()
    {
        return new ObservableCollection<Historia>(_favoritos);
    }

    // Verificar si una historia es favorita
    public bool EsFavorito(int historiaId)
    {
        return _favoritos.Any(f => f.Id == historiaId);
    }
}
using TheOldGrimoire.Models;
using System.Collections.ObjectModel;

namespace TheOldGrimoire.Services;

public enum OrdenSugerencias
{
    MayorVotos,
    MenorVotos,
    MasRecientes,
    MasAntiguas
}

public class ComunidadService
{
    private static ObservableCollection<Sugerencia> _sugerencias = new();
    private static int _siguienteIdSugerencia = 1;
    private static int _siguienteIdComentario = 1;

    public ComunidadService()
    {
        // Cargar datos de prueba solo una vez
        if (_sugerencias.Count == 0)
        {
            CargarDatosPrueba();
        }
    }

    private void CargarDatosPrueba()
    {
        var sugerencia1 = new Sugerencia
        {
            Id = _siguienteIdSugerencia++,
            NombreUsuario = "LectorNocturno",
            Titulo = "El Rey de Amarillo",
            Autor = "Robert W. Chambers",
            Genero = "Terror Cósmico",
            Descripcion = "Una colección de relatos que inspiró a Lovecraft. El misterioso 'Rey de Amarillo' y la obra de teatro prohibida que enloquece a quien la lee. ¡Deberían añadirla!",
            FechaPublicacion = DateTime.Now.AddHours(-3),
            VotosNetos = 47
        };
        sugerencia1.Comentarios.Add(new Comentario
        {
            Id = _siguienteIdComentario++,
            SugerenciaId = sugerencia1.Id,
            NombreUsuario = "CthulhuFan",
            Texto = "¡Totalmente de acuerdo! Es un clásico que no puede faltar.",
            FechaPublicacion = DateTime.Now.AddHours(-2)
        });
        sugerencia1.Comentarios.Add(new Comentario
        {
            Id = _siguienteIdComentario++,
            SugerenciaId = sugerencia1.Id,
            NombreUsuario = "GrimorioLector",
            Texto = "La obra de teatro es genial, deberían adaptarla.",
            FechaPublicacion = DateTime.Now.AddMinutes(-45)
        });

        var sugerencia2 = new Sugerencia
        {
            Id = _siguienteIdSugerencia++,
            NombreUsuario = "SombraLiteraria",
            Titulo = "La Lotería",
            Autor = "Shirley Jackson",
            Genero = "Terror Psicológico",
            Descripcion = "Un pueblo pequeño celebra una tradición anual que esconde un oscuro secreto. El final te deja helado. Perfecta para esta app.",
            FechaPublicacion = DateTime.Now.AddDays(-1),
            VotosNetos = 89
        };

        var sugerencia3 = new Sugerencia
        {
            Id = _siguienteIdSugerencia++,
            NombreUsuario = "VigilanteNocturno",
            Titulo = "El Horla",
            Autor = "Guy de Maupassant",
            Genero = "Terror Psicológico",
            Descripcion = "Un diario sobre un hombre que siente una presencia invisible que lo atormenta. Escalofriante y muy influyente en el terror moderno.",
            FechaPublicacion = DateTime.Now.AddHours(-12),
            VotosNetos = 23
        };

        _sugerencias.Add(sugerencia1);
        _sugerencias.Add(sugerencia2);
        _sugerencias.Add(sugerencia3);
    }

    // Obtener sugerencias según el orden elegido
    public ObservableCollection<Sugerencia> ObtenerSugerencias(OrdenSugerencias orden = OrdenSugerencias.MayorVotos)
    {
        IEnumerable<Sugerencia> resultado = orden switch
        {
            OrdenSugerencias.MenorVotos =>
                _sugerencias.OrderBy(s => s.VotosNetos),
            OrdenSugerencias.MasRecientes =>
                _sugerencias.OrderByDescending(s => s.FechaPublicacion),
            OrdenSugerencias.MasAntiguas =>
                _sugerencias.OrderBy(s => s.FechaPublicacion),
            _ =>
                _sugerencias.OrderByDescending(s => s.VotosNetos)
        };

        return new ObservableCollection<Sugerencia>(resultado);
    }

    // Agregar nueva sugerencia
    public void AgregarSugerencia(Sugerencia sugerencia)
    {
        sugerencia.Id = _siguienteIdSugerencia++;
        sugerencia.FechaPublicacion = DateTime.Now;
        sugerencia.VotosNetos = 0;
        _sugerencias.Insert(0, sugerencia); // La nueva va arriba
    }

    // Votar arriba
    public void VotarArriba(Sugerencia sugerencia)
    {
        if (sugerencia.UsuarioVotoArriba)
        {
            // Quitar voto
            sugerencia.VotosNetos -= 1;
            sugerencia.UsuarioVotoArriba = false;
        }
        else
        {
            // Dar voto arriba
            sugerencia.VotosNetos += 1;
            sugerencia.UsuarioVotoArriba = true;

            // Si antes había votado abajo, quitar ese voto
            if (sugerencia.UsuarioVotoAbajo)
            {
                sugerencia.VotosNetos += 1;
                sugerencia.UsuarioVotoAbajo = false;
            }
        }
    }

    // Votar abajo
    public void VotarAbajo(Sugerencia sugerencia)
    {
        if (sugerencia.UsuarioVotoAbajo)
        {
            sugerencia.VotosNetos += 1;
            sugerencia.UsuarioVotoAbajo = false;
        }
        else
        {
            sugerencia.VotosNetos -= 1;
            sugerencia.UsuarioVotoAbajo = true;

            if (sugerencia.UsuarioVotoArriba)
            {
                sugerencia.VotosNetos -= 1;
                sugerencia.UsuarioVotoArriba = false;
            }
        }
    }

    // Agregar comentario
    public void AgregarComentario(int sugerenciaId, Comentario comentario)
    {
        var sugerencia = _sugerencias.FirstOrDefault(s => s.Id == sugerenciaId);
        if (sugerencia != null)
        {
            comentario.Id = _siguienteIdComentario++;
            comentario.SugerenciaId = sugerenciaId;
            comentario.FechaPublicacion = DateTime.Now;
            sugerencia.Comentarios.Add(comentario);
            sugerencia.NotificarComentariosCambiados();
        }
    }
}
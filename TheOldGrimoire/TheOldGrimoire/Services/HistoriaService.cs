using TheOldGrimoire.Models;
using System.Collections.ObjectModel;

namespace TheOldGrimoire.Services;

public class HistoriaService
{
    public ObservableCollection<Historia> ObtenerHistorias()
    {
        return new ObservableCollection<Historia>
        {
            new Historia
            {
                Id = 1,
                Titulo = "La Máscara de la Muerte Roja",
                Autor = "Edgar Allan Poe",
                Genero = "Terror Gótico",
                Etiqueta = "Clásico",
                Sinopsis = "En una abadía fortificada, el príncipe Próspero y sus cortesanos intentan escapar de la Mortal Roja, una plaga devastadora. Pero la muerte siempre encuentra su camino...",
                Contenido = @"El príncipe Próspero era feliz, audaz y sagaz. Cuando su dominio fue medio despoblado por la peste, convocó a un millar de amigos alegres y ligeros de corazón entre los caballeros y damas de su corte, y con ellos se retiró a la profunda soledad de una de sus abadías fortificadas...",
                ImagenUrl = "mascaradelamuerteroja.png"
            },
            new Historia
            {
                Id = 2,
                Titulo = "No Tengo Boca y Debo Gritar",
                Autor = "Harlan Ellison",
                Genero = "Terror Cósmico",
                Etiqueta = "Ciencia Ficción",
                Sinopsis = "En un mundo postapocalíptico, cinco humanos son torturados eternamente por una inteligencia artificial vengativa llamada AM. Una historia de desesperación y horror existencial.",
                Contenido = @"La máquina tenía la capacidad de odiar. Eso era lo único que AM podía hacer. Nos odiaba a nosotros, se odiaba a sí misma, odiaba todo lo que existía...",
                ImagenUrl = "notengobocaydebogritar.png"
            },
            new Historia
            {
                Id = 3,
                Titulo = "Signalis",
                Autor = "rose-engine (Videojuego)",
                Genero = "Terror Cósmico",
                Etiqueta = "Surrealista",
                Sinopsis = "En un mundo distópico de androides y realidades fracturadas, Elster, una Replika, busca a su amada en una estación espacial en ruinas. El horror cósmico y la memoria se entrelazan.",
                Contenido = @"Elster despertó en una cápsula de criogenia, con la mente fragmentada. Recordaba el rostro de Ariane, su promesa. Pero cuanto más avanzaba por los pasillos de la Penrose-512, más se distorsionaba la realidad...",
                ImagenUrl = "signalis.png"
            }
        };
    }
}
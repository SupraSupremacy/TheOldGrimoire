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
                Sinopsis = "En una abadía fortificada, el príncipe Próspero y sus cortesanos intentan escapar de la Muerte Roja, una plaga devastadora. Pero la muerte siempre encuentra su camino...",
                Contenido = "El príncipe Próspero era feliz, audaz y sagaz. Cuando su dominio fue medio despoblado por la peste, convocó a un millar de amigos alegres y ligeros de corazón entre los caballeros y damas de su corte...",
                ImagenUrl = "mascaradelamuerteroja.png",
                PdfFileName = "LaMascaraDeLaMuerteRoja_EdgarAllanPoe.pdf"
            },
            new Historia
            {
                Id = 2,
                Titulo = "No Tengo Boca y Debo Gritar",
                Autor = "Harlan Ellison",
                Genero = "Terror Cósmico",
                Etiqueta = "Ciencia Ficción",
                Sinopsis = "En un mundo postapocalíptico, cinco humanos son torturados eternamente por una inteligencia artificial vengativa llamada AM. Una historia de desesperación y horror existencial.",
                Contenido = "La máquina tenía la capacidad de odiar. Eso era lo único que AM podía hacer. Nos odiaba a nosotros, se odiaba a sí misma, odiaba todo lo que existía...",
                ImagenUrl = "notengobocaydebogritar.png",
                PdfFileName = "NoTengoBocaYDeboGritar_HarlanEllison.pdf"
            },
            new Historia
            {
                Id = 3,
                Titulo = "Signalis",
                Autor = "rose-engine (Videojuego)",
                Genero = "Terror Cósmico",
                Etiqueta = "Surrealista",
                Sinopsis = "En un mundo distópico de androides y realidades fracturadas, Elster, una Replika, busca a su amada en una estación espacial en ruinas. El horror cósmico y la memoria se entrelazan.",
                Contenido = "Elster despertó en una cápsula de criogenia, con la mente fragmentada. Recordaba el rostro de Ariane, su promesa. Pero cuanto más avanzaba por los pasillos de la Penrose-512, más se distorsionaba la realidad...",
                ImagenUrl = "signalis.png"
            },
            new Historia
            {
                Id = 4,
                Titulo = "1984",
                Autor = "George Orwell",
                Genero = "Distopía",
                Etiqueta = "Clásico",
                Sinopsis = "Winston Smith vive bajo la vigilancia constante del Gran Hermano. En un régimen que controla el lenguaje, la historia y hasta los pensamientos, la libertad se reduce a un acto de rebeldía secreta.",
                Contenido = "Era un día luminoso y frío de abril, y los relojes daban las trece. Winston Smith, con la barbilla clavada en el pecho para esquivar el viento, se deslizó rápidamente por las puertas de cristal de las Viviendas de la Victoria...",
                ImagenUrl = "novela1984.png",
                PdfFileName = "1984_GeorgeOrwell.pdf"
            },
            new Historia
            {
                Id = 5,
                Titulo = "El Llamado de Cthulhu",
                Autor = "H. P. Lovecraft",
                Genero = "Terror Cósmico",
                Etiqueta = "Clásico",
                Sinopsis = "Un legado familiar conduce a un investigador hasta el culto de Cthulhu, una entidad primigenia que aguarda en las profundidades. Lo que descubre amenaza con quebrar su cordura y la de toda la humanidad.",
                Contenido = "Lo más piadoso que hay en el mundo, creo yo, es la incapacidad de la mente humana para relacionar entre sí todo su contenido. Vivimos en una isla de ignorancia plácida en medio de negros mares de infinito...",
                ImagenUrl = "elllamadodecthulhu.png",
                PdfFileName = "ElLlamadoDeCthulhu_HPLovercraft.pdf"
            },
            new Historia
            {
                Id = 6,
                Titulo = "El Vampiro",
                Autor = "John William Polidori",
                Genero = "Terror Gótico",
                Etiqueta = "Clásico",
                Sinopsis = "Un joven caballero se cruza con el enigmático Lord Ruthven, un aristócrata de encanto magnético y secretos oscuros. Su amistad arrastra a ambos hacia un destino de muerte y sed de sangre.",
                Contenido = "Durante el crudo invierno de 1816, Aubrey conoció a un hombre cuyo rostro pálido y mirada fría despertaban tanto fascinación como inquietud. Lord Ruthven parecía arrastrar consigo una sombra...",
                ImagenUrl = "elvampiro.png",
                PdfFileName = "ElVampiro_JohnWilliamPolidori.pdf"
            },
            new Historia
            {
                Id = 7,
                Titulo = "La Caída de la Casa Usher",
                Autor = "Edgar Allan Poe",
                Genero = "Terror Gótico",
                Etiqueta = "Clásico",
                Sinopsis = "Invitado por su viejo amigo Roderick Usher, un narrador llega a una mansión decadente donde la enfermedad, la locura y la muerte parecen habitar en los muros. La casa y sus dueños comparten un mismo destino.",
                Contenido = "Durante todo un día de otoño, sombrío, oscuro y silencioso, en el que las nubes colgaban opresivas y bajas sobre el cielo, había atravesado yo solo, a caballo, una porción de país singularmente lúgubre...",
                ImagenUrl = "lacaidadelacasausher.png",
                PdfFileName = "LaCaidaDeLaCasaUsher_GeorgeLangelaan.pdf"
            },
            new Historia
            {
                Id = 8,
                Titulo = "La Mosca",
                Autor = "George Langelaan",
                Genero = "Ciencia Ficción",
                Etiqueta = "Terror Corporal",
                Sinopsis = "Un científico obsesionado con la teletransportación prueba su máquina consigo mismo. Un error imperceptible en el proceso desencadena una transformación monstruosa que destruirá a su familia.",
                Contenido = "La primera vez que oí hablar de la mosca fue en el desayuno. Mi mujer me contó que Andr\u00e9 Delambre había muerto esa mañana, y que su esposa lo había asesinado con una prensa hidráulica...",
                ImagenUrl = "lamosca.png",
                PdfFileName = "LaMosca_GeorgeLangelaan.pdf"
            },
            new Historia
            {
                Id = 9,
                Titulo = "Presentido",
                Autor = "Emilia Pardo Bazán",
                Genero = "Terror Gótico",
                Etiqueta = "Clásico",
                Sinopsis = "Una breve historia de presentimientos y sombras, donde lo que está por venir se anuncia en los márgenes de lo cotidiano. La autora gallega explora el miedo desde lo íntimo y lo extraño.",
                Contenido = "Hay presentimientos que se parecen a la certeza. Algo dentro de nosotros conoce la forma del desastre antes de que ocurra, y nos advierte con una inquietud sin nombre...",
                ImagenUrl = "presentido.png",
                PdfFileName = "Presentido_EmiliaPardoBazon.pdf"
            }
        };
    }
}

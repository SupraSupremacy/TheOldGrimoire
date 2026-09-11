using System;
using System.Collections.Generic;
using System.Text;

namespace TheOldGrimoire.Models;

public class Historia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Sinopsis { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public string Etiqueta { get; set; } = string.Empty;
    public string ImagenUrl { get; set; } = string.Empty;
    public bool EsFavorito { get; set; } = false;
}
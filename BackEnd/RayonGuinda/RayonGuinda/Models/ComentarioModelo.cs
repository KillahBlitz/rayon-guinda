using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ComentarioModelo
{
    public int ComentarioId { get; set; }

    public string AutorComentario { get; set; } = null!;

    public string ContenidoComentario { get; set; } = null!;

    public int PublicacionId { get; set; }

    public virtual PublicacionModelo Publicacion { get; set; } = null!;
}

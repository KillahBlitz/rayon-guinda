using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class PublicacionModelo
{
    public int PublicacionId { get; set; }

    public string AutorPublicacion { get; set; } = null!;

    public string ContenidoPublicacion { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public virtual ICollection<ComentarioModelo> Comentarios { get; set; } = new List<ComentarioModelo>();

    public virtual ICollection<ForoModelo> Foros { get; set; } = new List<ForoModelo>();
}

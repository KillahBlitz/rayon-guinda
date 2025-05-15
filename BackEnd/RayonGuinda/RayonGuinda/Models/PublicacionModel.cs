using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class PublicacionModel
{
    public int PublicacionId { get; set; }

    public string AutorPublicacion { get; set; } = null!;

    public string ContenidoPublicacion { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public virtual ICollection<ComentarioModel> Comentarios { get; set; } = new List<ComentarioModel>();

    public virtual ICollection<ForoModel> Foros { get; set; } = new List<ForoModel>();
}

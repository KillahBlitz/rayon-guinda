using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class TareaModelo
{
    public int TareaId { get; set; }

    public string AutorPublicacion { get; set; } = null!;

    public string ContenidoPublicacion { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public int Calificar { get; set; }

    public virtual ICollection<CalificacionModelo> Calificacions { get; set; } = new List<CalificacionModelo>();

    public virtual ICollection<CalificacionModelo> CalificacionsNavigation { get; set; } = new List<CalificacionModelo>();
}

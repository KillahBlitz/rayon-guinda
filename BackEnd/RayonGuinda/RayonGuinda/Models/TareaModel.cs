using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class TareaModel
{
    public int TareaId { get; set; }

    public string AutorPublicacion { get; set; } = null!;

    public string ContenidoPublicacion { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public int Calificar { get; set; }

    public virtual ICollection<CalificacionModel> Calificacions { get; set; } = new List<CalificacionModel>();

    public virtual ICollection<CalificacionModel> CalificacionsNavigation { get; set; } = new List<CalificacionModel>();
}

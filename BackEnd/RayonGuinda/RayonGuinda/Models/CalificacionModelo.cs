using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class CalificacionModelo
{
    public int CalificacionId { get; set; }

    public string AlumnoCalificacion { get; set; } = null!;

    public int Calificacion1 { get; set; }

    public virtual ICollection<TareaModelo> Tareas { get; set; } = new List<TareaModelo>();

    public virtual ICollection<TareaModelo> TareasNavigation { get; set; } = new List<TareaModelo>();
}

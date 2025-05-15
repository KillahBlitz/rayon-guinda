using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class CalificacionModel
{
    public int CalificacionId { get; set; }

    public string AlumnoCalificacion { get; set; } = null!;

    public int Calificacion1 { get; set; }

    public virtual ICollection<TareaModel> Tareas { get; set; } = new List<TareaModel>();

    public virtual ICollection<TareaModel> TareasNavigation { get; set; } = new List<TareaModel>();
}

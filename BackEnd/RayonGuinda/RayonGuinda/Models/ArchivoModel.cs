using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ArchivoModel
{
    public int ArchivoId { get; set; }

    public string AlumnoResponsable { get; set; } = null!;

    public int PesoArchivo { get; set; }

    public DateTime FechaPublicacion { get; set; }
}

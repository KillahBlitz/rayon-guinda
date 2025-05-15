using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ParticipanteModel
{
    public int IndexUser { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Rol { get; set; } = null!;
}

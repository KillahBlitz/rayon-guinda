using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ForoModelo
{
    public int ForoId { get; set; }

    public string Administrador { get; set; } = null!;

    public string NombreForo { get; set; } = null!;

    public int NumIntegrantes { get; set; }

    public virtual ICollection<PublicacionModelo> Publicacions { get; set; } = new List<PublicacionModelo>();

    public virtual ICollection<UsuarioModelo> Users { get; set; } = new List<UsuarioModelo>();
}

using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class GrupoModelo
{
    public int GrupoId { get; set; }

    public string Administrador { get; set; } = null!;

    public string NombreGrupo { get; set; } = null!;

    public string ClaveAcceso { get; set; } = null!;

    public int NumIntegrantes { get; set; }

    public virtual ICollection<UsuarioModelo> Users { get; set; } = new List<UsuarioModelo>();
}

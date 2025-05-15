using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class GrupoModel
{
    public int GrupoId { get; set; }

    public string Administrador { get; set; } = null!;

    public string NombreGrupo { get; set; } = null!;

    public string ClaveAcceso { get; set; } = null!;

    public int NumIntegrantes { get; set; }

    public virtual ICollection<UsuarioModel> Users { get; set; } = new List<UsuarioModel>();
}

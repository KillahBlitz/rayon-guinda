using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ForoModel
{
    public int ForoId { get; set; }

    public string Administrador { get; set; } = null!;

    public string NombreForo { get; set; } = null!;

    public int NumIntegrantes { get; set; }

    public virtual ICollection<PublicacionModel> Publicacions { get; set; } = new List<PublicacionModel>();

    public virtual ICollection<UsuarioModel> Users { get; set; } = new List<UsuarioModel>();
}

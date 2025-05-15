using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class UsuarioModelo
{
    public int UserId { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string NumBoleta { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string CorreoInstitucional { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<ChatModelo> Chats { get; set; } = new List<ChatModelo>();

    public virtual ICollection<ForoModelo> Foros { get; set; } = new List<ForoModelo>();

    public virtual ICollection<GrupoModelo> Grupos { get; set; } = new List<GrupoModelo>();
}

using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class UsuarioModel
{
    public int UserId { get; set; }

    public string? ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; } = null!;

    public string? Nombres { get; set; } = null!;

    public string? NumBoleta { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string CorreoInstitucional { get; set; } = null!;

    public string? Contraseña { get; set; } = null!;

    public virtual ICollection<ChatModel> Chats { get; set; } = new List<ChatModel>();

    public virtual ICollection<ForoModel> Foros { get; set; } = new List<ForoModel>();

    public virtual ICollection<GrupoModel> Grupos { get; set; } = new List<GrupoModel>();
}

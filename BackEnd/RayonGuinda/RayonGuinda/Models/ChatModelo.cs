using System;
using System.Collections.Generic;

namespace RayonGuinda.Models;

public partial class ChatModelo
{
    public int ChatId { get; set; }

    public string OtherUser { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<UsuarioModelo> Users { get; set; } = new List<UsuarioModelo>();
}

using System;
using System.Collections.Generic;

namespace animepersonajesWebApi.Models;

public partial class Anime
{
    public Guid Id { get; set; }

    public string Anime1 { get; set; } = null!;

    public virtual ICollection<Personaje> Personajes { get; set; } = new List<Personaje>();
}

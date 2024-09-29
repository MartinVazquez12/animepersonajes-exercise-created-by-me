using System;
using System.Collections.Generic;

namespace animepersonajesWebApi.Models;

public partial class Personaje
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ocupacion { get; set; } = null!;

    public string Localizacion { get; set; } = null!;

    public string Edad { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public bool Vivo { get; set; }

    public Guid IdAnime { get; set; }

    public virtual Anime IdAnimeNavigation { get; set; } = null!;
}

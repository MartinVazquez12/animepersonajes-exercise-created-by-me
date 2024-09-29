using animepersonajesWebApi.Models;

namespace animepersonajesWebApi.Dtos
{
    public class PersonajePostDto
    {
        public Guid id_post { get; set; }

        public string nombrepost { get; set; } = null!;

        public string ocupost { get; set; } = null!;

        public string locpost { get; set; } = null!;

        public string edadpost { get; set; } = null!;

        public string generopost { get; set; } = null!;

        public bool vivopost { get; set; }

        public Guid id_animepost { get; set; }

    }
}

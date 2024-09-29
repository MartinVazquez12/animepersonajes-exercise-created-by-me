using animepersonajesWebApi.Models;

namespace animepersonajesWebApi.Dtos
{
    public class PersonajeDto
    {
        public Guid id_pers { get; set; }
        public string nombredto { get; set; } = null!;

        public string ocupdto { get; set; } = null!;

        public string locdto { get; set; } = null!;

        public string edadto { get; set; } = null!;

        public string generodto { get; set; } = null!;

        public bool vivodto { get; set; }

        public string animename { get; set; }
    }
}

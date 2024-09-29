using animepersonajesWebApi.Models;

namespace animepersonajesWebApi.Repositories.INT
{
    public interface IPersonajeRepo
    {
        Task<List<Personaje>> GetAll();
        Task<Personaje> GetById(Guid id);
        Task<Personaje> Add(Personaje personaje);
        Task<bool> ExistePersonaje(string nombre);
    }
}

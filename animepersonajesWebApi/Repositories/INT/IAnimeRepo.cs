using animepersonajesWebApi.Models;

namespace animepersonajesWebApi.Repositories.INT
{
    public interface IAnimeRepo
    {
        Task<List<Anime>> GetAll();
    }
}

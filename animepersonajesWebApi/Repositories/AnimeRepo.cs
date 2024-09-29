using animepersonajesWebApi.Models;
using animepersonajesWebApi.Repositories.INT;
using Microsoft.EntityFrameworkCore;

namespace animepersonajesWebApi.Repositories
{
    public class AnimeRepo : IAnimeRepo
    {
        private readonly PersonajesanimesContext _context;

        public AnimeRepo(PersonajesanimesContext context) {
            _context = context;
        }

        public async Task<List<Anime>> GetAll()
        {
            return await _context.Animes.ToListAsync();
        }
    }
}

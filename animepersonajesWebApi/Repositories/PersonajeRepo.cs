using animepersonajesWebApi.Models;
using animepersonajesWebApi.Repositories.INT;
using Microsoft.EntityFrameworkCore;

namespace animepersonajesWebApi.Repositories
{
    public class PersonajeRepo : IPersonajeRepo
    {
        private readonly PersonajesanimesContext _context;

        public PersonajeRepo(PersonajesanimesContext context)
        {
            _context = context;
        }

        public async Task<Personaje> Add(Personaje personaje)
        {
            _context.Add(personaje);
            await _context.SaveChangesAsync();
            return personaje;
        }

        public async Task<bool> ExistePersonaje(string nombre)
        {
            var persExiste = await _context.Personajes.AnyAsync(x=> x.Nombre.Equals(nombre));
        
            return persExiste;
        }

        public async Task<List<Personaje>> GetAll()
        {
            return await _context.Personajes
                .Include(x=> x.IdAnimeNavigation)
                .ToListAsync();
        }

        public async Task<Personaje> GetById(Guid id)
        {
            var jugador = await _context.Personajes
                .Include (x=> x.IdAnimeNavigation)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (jugador == null)
            {
                throw new Exception();
            }
            return jugador;
        }
    }
}

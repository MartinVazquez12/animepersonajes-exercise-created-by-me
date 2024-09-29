using animepersonajesWebApi.Dtos;
using animepersonajesWebApi.Models;
using animepersonajesWebApi.Repositories.INT;
using animepersonajesWebApi.Services.INT;
using animepersonajesWebApi.Validators;
using AutoMapper;
using System.Net;

namespace animepersonajesWebApi.Services
{
    public class FinalService : IFinalService
    {
        private readonly IPersonajeRepo _persRepo;
        private readonly IAnimeRepo _animeRepo;
        private readonly IMapper _mapper;
        private readonly PersonajePostDtoValidator _validator;

        public FinalService(IPersonajeRepo persRepo, IAnimeRepo animeRepo, IMapper mapper, PersonajePostDtoValidator validator)
        {
            _persRepo = persRepo;
            _animeRepo = animeRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponseDto<List<AnimeDto>>> GetAnimesAsync()
        {
            var response = new ApiResponseDto<List<AnimeDto>>();

            var listAnimes = await _animeRepo.GetAll();

            if(listAnimes != null && listAnimes.Count > 0)
            {
                var animesDto = _mapper.Map<List<AnimeDto>>(listAnimes);
                response.Success = true;
                response.Data = animesDto;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron animes", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PersonajeDto>> GetPersonajeById(Guid id)
        {
            var response = new ApiResponseDto<PersonajeDto>();

            var pers = await _persRepo.GetById(id);

            if(pers != null)
            {
                var persDto = _mapper.Map<PersonajeDto>(pers);
                response.Success = true;
                response.Data = persDto;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontro personaje con ese id", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<PersonajeDto>>> GetPersonajesAsync()
        {
            var response = new ApiResponseDto<List<PersonajeDto>>();

            var listPers = await _persRepo.GetAll();

            if (listPers != null && listPers.Count > 0)
            {
                var persDto = _mapper.Map<List<PersonajeDto>>(listPers);
                response.Success = true;
                response.Data = persDto;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron personajes", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PersonajePostDto>> PostPersonaje(PersonajePostDto personaje)
        {
            var response = new ApiResponseDto<PersonajePostDto>();

            var validacion = await _validator.ValidateAsync(personaje);

            if(!validacion.IsValid)
            {
                response.SetError("No se pudo validar", HttpStatusCode.InternalServerError);
                return response;
            }

            try
            {
                var existePers = await _persRepo.ExistePersonaje(personaje.nombrepost);

                if (existePers)
                {
                    response.SetError("Ya existe el personaje", HttpStatusCode.InternalServerError);
                    return response;
                }

                var pers = _mapper.Map<Personaje>(personaje);
                pers.Id = Guid.NewGuid();

                await _persRepo.Add(pers);

                var persAdd = _mapper.Map<PersonajePostDto>(pers);
                response.Success = true;
                response.Data = persAdd;
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception)
            {
                response.SetError("Error al añadir el personaje", HttpStatusCode.InternalServerError);
                throw;
            }
        }
    }
}

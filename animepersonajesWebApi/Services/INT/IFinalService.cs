using animepersonajesWebApi.Dtos;

namespace animepersonajesWebApi.Services.INT
{
    public interface IFinalService
    {
        Task<ApiResponseDto<List<AnimeDto>>> GetAnimesAsync();
        Task<ApiResponseDto<List<PersonajeDto>>> GetPersonajesAsync();
        Task<ApiResponseDto<PersonajeDto>> GetPersonajeById(Guid id);
        Task<ApiResponseDto<PersonajePostDto>> PostPersonaje(PersonajePostDto personaje);
    }
}

using animepersonajesWebApi.Dtos;
using animepersonajesWebApi.Services.INT;
using Microsoft.AspNetCore.Mvc;

namespace animepersonajesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalController : ControllerBase
    {
        private readonly IFinalService _service;
        public FinalController(IFinalService service)
        {
            _service = service;
        }

        [HttpGet("/GetAnimes")]
        public async Task<ActionResult> GetAnimes()
        {
            return Ok(await _service.GetAnimesAsync());
        }

        [HttpGet("/GetPersonajes")]
        public async Task<ActionResult> GetPersonajes()
        {
            return Ok(await _service.GetPersonajesAsync());
        }

        [HttpGet("/GetPersonajeById/{id}")]
        public async Task<ActionResult> GetPersonajeById(Guid id)
        {
            var result = await _service.GetPersonajeById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpPost("/PostPersonaje")]
        public async Task<IActionResult> PostPersonaje([FromBody] PersonajePostDto personaje)
        {
            try
            {
                var response = await _service.PostPersonaje(personaje);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

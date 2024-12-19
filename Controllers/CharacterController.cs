using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPIBackend.Services;

namespace RickAndMortyAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly RickAndMortyApiService _apiService;

        public CharacterController(RickAndMortyApiService apiService)
        {
            _apiService = apiService;
        }

        // Obtener todos los personajes
        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _apiService.GetCharactersAsync();
            return Ok(characters);
        }

        // Obtener un personaje por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _apiService.GetCharacterByIdAsync(id);
            if (character == null) return NotFound();
            return Ok(character);
        }
    }
}

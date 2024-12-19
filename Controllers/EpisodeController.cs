using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPIBackend.Services;

namespace RickAndMortyAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly RickAndMortyApiService _apiService;

        public EpisodeController(RickAndMortyApiService apiService)
        {
            _apiService = apiService;
        }

        // Obtener todos los episodios
        [HttpGet]
        public async Task<IActionResult> GetEpisodes()
        {
            var episodes = await _apiService.GetEpisodesAsync();
            return Ok(episodes);
        }

        // Obtener un episodio por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisodeById(int id)
        {
            var episode = await _apiService.GetEpisodeByIdAsync(id);
            if (episode == null) return NotFound();
            return Ok(episode);
        }
    }
}

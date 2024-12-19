using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPIBackend.Services;

namespace RickAndMortyAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly RickAndMortyApiService _apiService;

        public LocationController(RickAndMortyApiService apiService)
        {
            _apiService = apiService;
        }

        // Obtener todas las ubicaciones
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _apiService.GetLocationsAsync();
            return Ok(locations);
        }

        // Obtener una ubicación por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _apiService.GetLocationByIdAsync(id);
            if (location == null) return NotFound();
            return Ok(location);
        }
    }
}

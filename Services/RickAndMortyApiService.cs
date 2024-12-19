using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RickAndMortyAPIBackend.Models.Location;
using RickAndMortyAPIBackend.Models.Character;
using RickAndMortyAPIBackend.Models.Episode;

namespace RickAndMortyAPIBackend.Services
{
    public class RickAndMortyApiService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los episodios
        public async Task<List<Episode>> GetEpisodesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://rickandmortyapi.com/api/episode");
            var result = JsonConvert.DeserializeObject<ApiResponse<Episode>>(response);
            return result.Results;
        }

        // Obtener un episodio por ID
        public async Task<Episode> GetEpisodeByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://rickandmortyapi.com/api/episode/{id}");
            return JsonConvert.DeserializeObject<Episode>(response);
        }

        // Obtener todos los personajes
        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await _httpClient.GetStringAsync("https://rickandmortyapi.com/api/character");
            var result = JsonConvert.DeserializeObject<ApiResponse<Character>>(response);
            return result.Results;
        }

        // Obtener un personaje por ID
        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://rickandmortyapi.com/api/character/{id}");
            return JsonConvert.DeserializeObject<Character>(response);
        }

        // Obtener todas las ubicaciones
        public async Task<List<Models.Location.Location>> GetLocationsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://rickandmortyapi.com/api/location");
            var result = JsonConvert.DeserializeObject<ApiResponse<Models.Location.Location>>(response);
            return result.Results;
        }

        // Obtener una ubicación por ID
        public async Task<Models.Location.Location> GetLocationByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://rickandmortyapi.com/api/location/{id}");
            return JsonConvert.DeserializeObject<Models.Location.Location>(response);
        }
    }
    public class ApiResponse<T>
    {
        public Info Info { get; set; }
        public List<T> Results { get; set; }
    }
    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}

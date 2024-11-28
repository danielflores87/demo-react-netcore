using demo.back.Api.DTOs;
using demo.back.Application.Utils;
using demo.back.Domain.Entities;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace demo.back.Application.Services
{

  public class MarvelApiService
    {
        private readonly string _publicKey = "2fbf4188ff44981d867163693e2d173e";
        private readonly string _privateKey = "fc7f024f1dec7c84dddbf043103c75d023b81276";
        private readonly HttpClient _httpClient;

        public MarvelApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<IEnumerable<Comic?>>> GetComicsAsync(string? title, int page, int perPage)
        {
            var timestamp = DateTime.UtcNow.Ticks.ToString();
            var hash = GenerateHash(timestamp);
            var offset = (page - 1) * perPage;
            var url = $"https://gateway.marvel.com/v1/public/comics?ts={timestamp}&apikey={_publicKey}&hash={hash}&offset={offset}&limit={perPage}";

            if (!string.IsNullOrEmpty(title))
            {
                url += $"&titleStartsWith={title}";
            }

            var response = await _httpClient.GetStringAsync(url);

            var comicsResponse = JsonConvert.DeserializeObject<ComicsResponseDTO>(response);
            return new ApiResponse<IEnumerable<Comic?>>(comicsResponse.Data.Results, EResponseCodes.Success, null, comicsResponse.Data.Total);
        }
        private string GenerateHash(string timestamp)
        {
            var combined = timestamp + _privateKey + _publicKey;
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(combined));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

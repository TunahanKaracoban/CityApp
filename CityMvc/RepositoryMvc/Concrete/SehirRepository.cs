using CityMvc.Models;
using CityMvc.RepositoryMvc.Abstract;
using CityWebApi.Repository.Abstract;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace CityMvc.RepositoryMvc.Concrete
{
    public class SehirRepository : ISehirRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public SehirRepository(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration.GetConnectionString("WebApiBaseUrl"));
        }

        public async Task CreateAsync(Sehir entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/cities", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Sehir> GetAsync(Expression<Func<Sehir, bool>> filter = null, bool tracked = true)
        {
            var query = "api/cities";
            if (filter != null)
            {
                query += "?filter=" + filter.ToString();
            }
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Sehir>(json);
        }

        public async Task<List<Sehir>> GetAllAsync(Expression<Func<Sehir, bool>> filter = null)
        {
            var query = "api/cities";
            if (filter != null)
            {
                query += "?filter=" + filter.ToString();
            }
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Sehir>>(json);
        }

        public async Task RemoveAsync(Sehir entity)
        {
            var response = await _httpClient.DeleteAsync("api/cities/" + entity.Id);
            response.EnsureSuccessStatusCode();
        }

        public async Task SaveAsync()
        {
            // No-op since Web API uses EF and saves changes immediately
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Sehir entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/cities/" + entity.Id, content);
            response.EnsureSuccessStatusCode();
        }
    }
}

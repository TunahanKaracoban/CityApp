using CityMvc.Models;
using CityMvc.Repository.Abstract;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace CityMvc.Repository.Concrete
{
    public class CityRepository : ICityRepository
    {
        private readonly HttpClient _httpClient;

        public CityRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<City>> GetAllAsync(Expression<Func<City, bool>> filter = null)
        {
            var response = await _httpClient.GetAsync("https://localhost:7267/api/City");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<List<City>>(content);

            if (filter != null)
            {
                return cities.AsQueryable().Where(filter).ToList();
            }

            return cities;
        }

        public async Task<City> GetAsync(Expression<Func<City, bool>> filter = null)
        {
            var cities = await GetAllAsync(filter);
            return cities.FirstOrDefault();
        }

        public async Task CreateAsync(City entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7267/api/City", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(City entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7267/api/City/{entity.Id}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveAsync(City entity)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7267/api/City/{entity.Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task SaveAsync()
        {
          
            await Task.CompletedTask;
        }

      
    }
}

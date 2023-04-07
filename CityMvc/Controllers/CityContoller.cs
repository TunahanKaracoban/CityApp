using CityMvc.Models;
using CityMvc.RepositoryMvc.Abstract;
using CityWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CityMvc.Controllers
{
    // CityController.cs
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly HttpClient _httpClient;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7267/api/")
            };
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("cities");
            var result = await response.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<IEnumerable<CityViewModel>>(result);

            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityViewModel city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            var newCity = new City
            {
                CityName = city.CityName,
                CountryName = city.CountryName
            };

            await _httpClient.PostAsJsonAsync("cities", newCity);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"cities/{id}");
            var result = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityViewModel>(result);

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CityViewModel city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            var updatedCity = new City
            {
                Id = city.Id,
                CityName = city.CityName,
                CountryName = city.CountryName
            };

            await _httpClient.PutAsJsonAsync($"cities/{city.Id}", updatedCity);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"cities/{id}");
            var result = await response.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<CityViewModel>(result);

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"cities/{id}");

            return RedirectToAction(nameof(Index));
        }
    }


}

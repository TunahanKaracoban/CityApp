using CityMvc.Models;
using CityMvc.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace CityMvc.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityRepository.GetAllAsync();
            return View(cities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var city = await _cityRepository.GetAsync(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            await _cityRepository.CreateAsync(city);
            await _cityRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityRepository.GetAsync(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(city);
            }

            await _cityRepository.UpdateAsync(city);
            await _cityRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityRepository.GetAsync(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _cityRepository.GetAsync(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            await _cityRepository.RemoveAsync(city);
            await _cityRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
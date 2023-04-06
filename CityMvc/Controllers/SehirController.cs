using CityMvc.Models;
using CityMvc.RepositoryMvc.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CityMvc.Controllers
{
    public class SehirController : Controller
    {
        private readonly ISehirRepository _sehirRepository;

        public SehirController(ISehirRepository sehirRepository)
        {
            _sehirRepository = sehirRepository;
        }
        // Tüm şehirleri getirir
        public async Task<IActionResult> Index()
        {
            var sehirler = await _sehirRepository.GetAllAsync();
            return View(sehirler);
        }

        // Şehir detaylarını getirir
        public async Task<IActionResult> Details(int id)
        {
            var sehir = await _sehirRepository.GetAsync(x => x.Id == id);
            if (sehir == null)
            {
                return NotFound();
            }
            return View(sehir);
        }

        // Yeni şehir ekleme sayfasını gösterir
        public IActionResult Create()
        {
            return View();
        }

        // Yeni şehir ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                await _sehirRepository.CreateAsync(sehir);
                await _sehirRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sehir);
        }

        // Şehir düzenleme sayfasını gösterir
        public async Task<IActionResult> Edit(int id)
        {
            var sehir = await _sehirRepository.GetAsync(x => x.Id == id);
            if (sehir == null)
            {
                return NotFound();
            }
            return View(sehir);
        }

        // Şehir düzenleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sehir sehir)
        {
            if (id != sehir.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingSehir = await _sehirRepository.GetAsync(filter: s => s.Id == sehir.Id);
                if (existingSehir == null)
                {
                    return NotFound();
                }

                existingSehir.SehirAdi = sehir.SehirAdi;
                existingSehir.UlkeAdi = sehir.UlkeAdi;

                try
                {
                    await _sehirRepository.UpdateAsync(existingSehir);
                    await _sehirRepository.SaveAsync();
                }
                catch
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(sehir);
        }


        // Şehir silme işlemi
        public async Task<IActionResult> Delete(int id)
        {
            var sehir = await _sehirRepository.GetAsync(x => x.Id == id);
            if (sehir == null)
            {
                return NotFound();
            }

            return View(sehir);
        }

        // Şehir silme onayı
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sehir = await _sehirRepository.GetAsync(x => x.Id == id);
            await _sehirRepository.RemoveAsync(sehir);
            await _sehirRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

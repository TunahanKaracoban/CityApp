using CityWebApi.Data;
using CityWebApi.Models;
using CityWebApi.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CityWebApi.Repository.Concrete
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _db;
        public CityRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(City entity)
        {
            await _db.Cities.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<City> GetAsync(Expression<Func<City, bool>> filter = null, bool tracked = true)
        {
            IQueryable<City> query = _db.Cities;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<City>> GetAllAsync(Expression<Func<City, bool>> filter = null)
        {
            IQueryable<City> query = _db.Cities;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(City entity)
        {
            _db.Cities.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(City entity)
        {
            _db.Cities.Update(entity);
            await SaveAsync();
        }

    
    }
}

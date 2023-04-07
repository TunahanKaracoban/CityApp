using CityMvc.RepositoryMvc.Abstract;
using CityWebApi.Data;
using CityWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CityMvc.RepositoryMvc.Concrete
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync(Expression<Func<City, bool>> filter = null)
        {
            IQueryable<City> query = _context.Cities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<City> GetAsync(Expression<Func<City, bool>> filter = null, bool tracked = true)
        {
            IQueryable<City> query = _context.Cities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (tracked)
            {
                return await query.FirstOrDefaultAsync();
            }
            else
            {
                return await query.AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task CreateAsync(City entity)
        {
            await _context.Cities.AddAsync(entity);
        }

        public async Task RemoveAsync(City entity)
        {
            _context.Cities.Remove(entity);
        }

        public async Task UpdateAsync(City entity)
        {
            _context.Cities.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

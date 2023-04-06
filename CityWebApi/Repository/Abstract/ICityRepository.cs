using CityWebApi.Models;
using System.Linq.Expressions;

namespace CityWebApi.Repository.Abstract
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync(Expression<Func<City, bool>> filter = null);
        Task<City> GetAsync(Expression<Func<City, bool>> filter = null, bool tracked = true);
        Task CreateAsync(City entity);
        Task RemoveAsync(City entity);

        Task UpdateAsync(City entity);
        Task SaveAsync();
    }
}

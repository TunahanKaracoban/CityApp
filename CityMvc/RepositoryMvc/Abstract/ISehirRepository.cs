using CityMvc.Models;
using System.Linq.Expressions;

namespace CityMvc.RepositoryMvc.Abstract
{
    public interface ISehirRepository
    {
        Task<List<Sehir>> GetAllAsync(Expression<Func<Sehir, bool>> filter = null);
        Task<Sehir> GetAsync(Expression<Func<Sehir, bool>> filter = null, bool tracked = true);
        Task CreateAsync(Sehir entity);
        Task RemoveAsync(Sehir entity);

        Task UpdateAsync(Sehir entity);
        Task SaveAsync();
    }
}

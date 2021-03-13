using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        Task<DbSet<T>> GetSetAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
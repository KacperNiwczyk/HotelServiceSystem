using System.Linq;
using System.Threading.Tasks;

namespace HotelServiceSystem.Core
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();

        T GetById(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly HotelServiceDatabaseContext HotelServiceDatabaseContext;

        public BaseRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext)
        {
            HotelServiceDatabaseContext = hotelServiceDatabaseContext;
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return HotelServiceDatabaseContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            await HotelServiceDatabaseContext.AddAsync(entity);
            await HotelServiceDatabaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            HotelServiceDatabaseContext.Update(entity);
            await HotelServiceDatabaseContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            HotelServiceDatabaseContext.Remove(entity);
            await HotelServiceDatabaseContext.SaveChangesAsync();

            return entity;
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Logic.Interfaces.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Data_access.Core.Repositories
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

        public TEntity GetById(int id)
        {
            return HotelServiceDatabaseContext.Set<TEntity>().Find(id);
        }

        public async Task<DbSet<TEntity>> GetSetAsync()
        {
            return await Task.FromResult(HotelServiceDatabaseContext.Set<TEntity>());
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

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            HotelServiceDatabaseContext.Remove(entity);
            await HotelServiceDatabaseContext.SaveChangesAsync();
        }
    }
}
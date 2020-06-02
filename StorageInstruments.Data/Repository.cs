using Microsoft.EntityFrameworkCore;
using StorageInstruments.DataContract.Repository;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageInstruments.Data
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        private readonly DbContext _context;
        private readonly ISeriLog Log;
        public BaseRepository(DbContext context, ISeriLog logger)
        {
            this._context = context;
            Log = logger;
        }

        public async Task<TEntity> FindOneAsync(long id)
        {
            var toReturn = await _context.Set<TEntity>().FindAsync(id);
            if (toReturn is null)
            {
                Log.WriteLog($"Did not found {typeof(TEntity).Name} with {id}", Microsoft.Extensions.Logging.LogLevel.Information);
            }
            else
            {
                Log.WriteLog($"FindOne {typeof(TEntity).Name} with {id}", Microsoft.Extensions.Logging.LogLevel.Information);
            }
            return toReturn;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var toReturn = await _context.Set<TEntity>().ToListAsync();
            int total = toReturn != null ? toReturn.Count : 0;
            Log.WriteLog($"GetAll {typeof(TEntity).Name} found {total}", Microsoft.Extensions.Logging.LogLevel.Information);
            return toReturn;
        }



        public async Task<TEntity> CreateAsync(TEntity toCreate)
        {
            _context.Set<TEntity>().Add(toCreate);
            var alteredTables = await _context.SaveChangesAsync();
            if (alteredTables <= 0)
            {
                Log.WriteLog($"Failed to Create {typeof(TEntity).Name}", Microsoft.Extensions.Logging.LogLevel.Error);
            }
            Log.WriteLog($"Created {typeof(TEntity).Name} with id {toCreate.Id}", Microsoft.Extensions.Logging.LogLevel.Information);
            return toCreate;
        }
        public async Task<List<TEntity>> CreateBulkAsync(List<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            var alteredTables = await _context.SaveChangesAsync();
            foreach (var entity in entities)
            {
                if (entity.Id >= 0)
                {
                    Log.WriteLog($"Failed to Create {typeof(TEntity).Name}", Microsoft.Extensions.Logging.LogLevel.Information);
                }
                Log.WriteLog($"Created {typeof(TEntity).Name} with id {entity.Id}", Microsoft.Extensions.Logging.LogLevel.Information);
            }
            return entities;
        }

        public async Task<TEntity> UpdateAsync(long id, TEntity toUpdate)
        {
            _context.Entry(toUpdate).State = EntityState.Modified;
            var alteredTables = await _context.SaveChangesAsync();
            if (alteredTables <= 0)
            {
                Log.WriteLog($"Failed to Update {typeof(TEntity).Name} with id {id}", Microsoft.Extensions.Logging.LogLevel.Information);
            }
            Log.WriteLog($"Updated {typeof(TEntity).Name} with id {id}", Microsoft.Extensions.Logging.LogLevel.Information);
            return toUpdate;
        }


        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await this.FindOneAsync(id);
            if (entity is null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            Log.WriteLog($"Deleted {typeof(TEntity).Name} with id {id}", Microsoft.Extensions.Logging.LogLevel.Information);
            return entity;
        }


    }
}

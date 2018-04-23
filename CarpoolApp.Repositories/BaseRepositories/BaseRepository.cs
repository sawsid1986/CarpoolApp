using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CarpoolApp.Repositories.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T>,IDisposable where T : class,ISoftDeletable
    {
        DbContext _dbModel;
        public BaseRepository(DbContext dbModel)
        {
            _dbModel = dbModel;
        }

        public async Task EditAsync(T t)
        {
            if (t.Id.HasValue)
            {
                t.UpdatedOn = DateTime.Now;
                t.IsActive = true;
                _dbModel.Set<T>().Attach(t);
                _dbModel.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
                await _dbModel.SaveChangesAsync();
            }
        }

        public async Task AddAsync(T t)
        {
            if (!t.Id.HasValue)
            {
                t.CreatedOn = DateTime.Now;
                t.UpdatedOn = DateTime.Now;
                t.IsActive = true;
                _dbModel.Set<T>().Add(t);
                await _dbModel.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var t = await GetAsync(predicate);
            t.UpdatedOn = DateTime.Now;
            t.IsActive = false;
            _dbModel.Set<T>().Attach(t);
            _dbModel.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            await _dbModel.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbModel.Set<T>().AsNoTracking().ToArrayAsync();
            }
            else
            {
                return await _dbModel.Set<T>().Where(predicate).AsNoTracking().ToArrayAsync();
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbModel.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIDAsync(int Id)
        {
            return await _dbModel.Set<T>().SingleOrDefaultAsync(entity => entity.Id.Value == Id);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbModel.Set<T>().AnyAsync();
            else
                return await _dbModel.Set<T>().AnyAsync(predicate);
        }

        public async Task<bool> AnyCurrentAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbModel.Set<T>().Where(t => t.IsActive).AnyAsync(predicate);
        }

        #region disponse

        bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            _dbModel.Dispose();    
            disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}

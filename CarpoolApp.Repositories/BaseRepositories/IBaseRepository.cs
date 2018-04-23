using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Repositories.BaseRepositories
{
    public interface IBaseRepository<T> where T : class, ISoftDeletable
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIDAsync(int Id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);
        Task<bool> AnyCurrentAsync(Expression<Func<T, bool>> predicate = null);
        Task AddAsync(T t);
        Task EditAsync(T t);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}

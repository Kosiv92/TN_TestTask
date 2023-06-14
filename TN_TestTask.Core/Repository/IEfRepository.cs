using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.Core
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        public Task<T?> GetByIdAsync(Guid id);

        public Task<T?> GetByIdIncludeAsync(Guid id, string includeEntityNames);

        public Task<IEnumerable<T>> GetAll();

        public Task<IEnumerable<T>> GetAllInclude(params Expression<Func<T, object>>[] includingEntities);

        public Task<Guid> CreateAsync(T entity);

        public Task Update(T entity);

        public Task DeleteAsync(Guid id);

        public Task SaveChangesAsync();
    }
}

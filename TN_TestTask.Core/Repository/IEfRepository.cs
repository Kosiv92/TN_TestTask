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

        public Task<IEnumerable<T>> GetAll();                

        public Task<Guid> CreateAsync(T entity);

        public Task Update(T entity);

        public Task DeleteAsync(Guid id);

        public Task SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<T?> GetByIdAsync(Guid id);

        public Task<IEnumerable<T>> GetAll();

        public Task<Guid> CreateAsync(T entity);

        public Task Update(T entity);

        public Task DeleteAsync(Guid id);
    }
}

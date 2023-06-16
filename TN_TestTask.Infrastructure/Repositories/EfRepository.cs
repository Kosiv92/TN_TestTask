using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TN_TestTask.Core;
using TN_TestTask.Core.Exceptions;

namespace TN_TestTask.Infrastructure
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        public DbContext _context;
        public DbSet<T> _dbSet;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new NotFoundException(nameof(entity), id);

            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _context.Set<T>()
                //.AsNoTracking()
                .ToListAsync();
        }                

        public async Task<T> GetByIdAsync(Guid id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);                                

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
        

        public Task Update(T entity)
        {            
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}

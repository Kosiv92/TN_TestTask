using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure.Interfaces
{
    internal interface IEfRepository<T> 
        : IBaseRepository<T> where T : BaseEntity
    {
        public Task SaveChangesAsync();
    }
}

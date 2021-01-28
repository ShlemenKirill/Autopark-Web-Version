using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IVVenicleRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        public Task<IEnumerable<TEntity>> SortBy(string order);
    }
}

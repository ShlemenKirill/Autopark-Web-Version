using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IOrdersRepository<TEntity>
    {        
        Task<IEnumerable<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task<TEntity> Get(int id);
    }
}

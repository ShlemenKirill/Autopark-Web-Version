using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IOrdersRepository<TEntity>
    {        
        List<TEntity> GetAll();
        
    }
}

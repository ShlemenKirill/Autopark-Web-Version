using Autopark_Web_Version.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IVOrderDetailsRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllById(int id);
    }
}

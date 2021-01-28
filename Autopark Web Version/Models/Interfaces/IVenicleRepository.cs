using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models
{
    public interface IVenicleRepository<TEntity>
    {
        Task Create(TEntity entity);
        Task Delete(int id);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task<IEnumerable<Venicles>> SortBy(string order);
        Task<double> CalculateTaxPerMounth(int id);
        Task<double> CalculateMaxKilometers(int id);
    }
}

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
        public List<Venicles> SortBy(string order);
        public double CalculateTaxPerMounth(int id);
        public double CalculateMaxKilometers(int id);
    }
}

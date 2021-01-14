using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models
{
    public interface IVenicleRepository<TEntity>
    {
        void Create(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        List<TEntity> GetAll();
        void Update(TEntity entity);
        public List<Venicles> SortBy(string order);
    }
}

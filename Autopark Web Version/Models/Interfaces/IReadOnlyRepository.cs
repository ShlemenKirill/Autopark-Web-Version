using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        public IEnumerable<T> SortBy(string order);
    }
}

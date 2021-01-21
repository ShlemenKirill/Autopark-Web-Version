using Autopark_Web_Version.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    public interface IVOrderDetailsRepository<T> where T : class
    {
        IEnumerable<T> GetAllById(int id);
    }
}

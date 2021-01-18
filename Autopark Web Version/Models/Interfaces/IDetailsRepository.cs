using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Interfaces
{
    interface IDetailsRepository
    {
        void Create(Details entity);
        void Delete(int id);
        Details Get(int id);
        List<Details> GetAll();
        void Update(Details entity);        
    }
}

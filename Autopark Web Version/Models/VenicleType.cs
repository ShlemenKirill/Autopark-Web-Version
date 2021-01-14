using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models
{
    public class VenicleType
    {
        public VenicleType()
        {
            Venicles = new HashSet<Venicles>();
        }
        public int VenicleTypeId { get; set; }        
        public string VeniclesType { get; set; }
        public double VenicleTax { get; set; }
        public virtual ICollection<Venicles> Venicles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Models
{
    public class VOrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string VenicleName { get; set; }
        public string DetailName { get; set; }
        public int Quantity { get; set; }
    }
}

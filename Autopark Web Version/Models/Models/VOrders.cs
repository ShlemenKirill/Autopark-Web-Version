using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Models
{
    public class VOrders
    {
        public int OrderId { get; set; }
        public string VenicleName { get; set; }
        public DateTime? Date { get; set; }
    }
}

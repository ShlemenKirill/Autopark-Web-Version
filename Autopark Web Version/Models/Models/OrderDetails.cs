using System;
using Autopark_Web_Version.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int VenicleId { get; set; }
        public int Quantity { get; set; }
        public int DetailId { get; set; }
        public virtual Venicles Venicles { get; set; }
        public virtual VenicleType VenicleType { get; set; }
        public virtual Details Details { get; set; }
    }
}

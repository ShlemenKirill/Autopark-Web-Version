using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Models
{
    public class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int OrderId { get; set; }
        public int VenicleId { get; set; }
        public DateTime? Date { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

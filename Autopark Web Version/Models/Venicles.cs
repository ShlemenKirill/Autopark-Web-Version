using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models
{
    public class Venicles
    {
        public int VenicleId { get; set; }
        public int VeniclesTypeId { get; set; }
        public string Engine { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public DateTime? Year { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public int Tank { get; set; }

        public virtual VenicleType VenicleType { get; set; }
    }
}

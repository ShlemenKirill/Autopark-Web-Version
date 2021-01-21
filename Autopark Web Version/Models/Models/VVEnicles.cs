using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Models
{
    public class VVEnicles
    {
        public int VenicleId { get; set; }
        public string VenicleType { get; set; }
        public string Engine { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public DateTime? Year { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public int Tank { get; set; }
        public double Consumption { get; set; }
    }
}

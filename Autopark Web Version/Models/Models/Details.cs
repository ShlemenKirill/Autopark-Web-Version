﻿using Autopark_Web_Version.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models
{
    public class Details
    {
        public Details()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

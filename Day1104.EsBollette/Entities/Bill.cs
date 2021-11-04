using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsBollette.Entities
{
    public class Bill
    {
        public int FixedQuota { get; set; } = 40;
        public decimal Consumption { get; set; }
        public decimal Amount { get; set; }
        public string CustomerCode { get; set; }
        public Customer Customer { get; set; }
    }
}

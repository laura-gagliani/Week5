using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsBollette.Entities
{
    public class Customer
    {
        public string FiscalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Bill> CustomerBills { get; set; } = new List<Bill>();
    }
}

using Day1104.EsBollette.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsBollette
{
    public static class BillManager
    {
        static List<Customer> customers = new List<Customer>() 
        { 
            new Customer {FirstName = "Laura", LastName = "Gagliani", FiscalCode = "GGLLRA95B49A564T"}
        };

        static List<Bill> bills = new List<Bill>();



        internal static bool GetByCode(string code, out Customer customer)
        {
            foreach (var item in customers)
            {
                if (item.FiscalCode == code)
                {
                    customer = item;
                    return true;
                }
            }
            customer = null;
            return false;
        }

        internal static decimal CalculateAmount(Bill newBill)
        {
            decimal amount;
            return amount = newBill.Consumption * 10 + newBill.FixedQuota;
        }

        internal static bool AddBill(Bill newBill)
        {
            if (newBill != null)
            {
                bills.Add(newBill);
                newBill.Customer.CustomerBills.Add(newBill);
                return true;
            }
            else return false;

        }
    }
}

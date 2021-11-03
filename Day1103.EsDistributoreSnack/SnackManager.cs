using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1103.EsDistributoreSnack
{
    public static class SnackManager
    {
        public static Dictionary<int, Snack> snacksDispenser = new Dictionary<int, Snack>();
       


        public static void PrintSnacks(Dictionary<int, Snack> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("Tasto " + item.Key + ": " + item.Value.Name + " - " + item.Value.Price + " euro");

            }
        }

        public static void AddSnacksToDispenser()
        {
            Snack snack1 = new Snack { Id = 1, Name = "Baiocchi", Price = 1.80 };
            Snack snack2 = new Snack { Id = 2, Name = "Crostatina all'albicocca", Price = 2};
            Snack snack3 = new Snack { Id = 3, Name = "Patatine", Price = 1.30 };
            Snack snack4 = new Snack { Id = 4, Name = "Schacchiatina al rosmarino", Price = 1.50 };

            snacksDispenser.Add(1, snack1);
            snacksDispenser.Add(2, snack2);
            snacksDispenser.Add(3, snack3);
            snacksDispenser.Add(4, snack4);
            

        }
    }
}

using System;

namespace Day1102.OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p1;                 // riferimento a persona -> punta a null, è null (non ho l'istanza)
                                       //non c'è ancora un'allocazione di memoria nell'heap
            Person p2 = new Person(); //effettiva ISTANZA di persona

            // p2. (...) non suggerisce nulla! i campi non sono accessibili a causa del livello di protezione (che è private)
            p2.Surname = "cicci"; //questo campo invece è public, è accessibile

            p1 = p2; //ora p1 punta a p2! c'è un indirizzo di memoria

            //p2.Age = 20; questo NON LO POSSO FARE, mancando il set nella proprietà è un read-only
            // Console.WriteLine(p2.Age); //stamperà 0, ovvero il valore di default per gli int perché non ho assegnato nulla

            p2.BirthDate = new DateTime(1980, 04, 25);
            p2.GetAge();
            Console.WriteLine(p2.Age);


            p1.Code = "";
            Console.WriteLine(p1.Code);


            p1.PrintInfo(); //è un metodo a cui accedo dall'istanza p1, non dalla classe Person !! NB.

            string res = p1.ToString();

            Person p3 = new Person("Sara", "Bianchi");
        }
    }
}

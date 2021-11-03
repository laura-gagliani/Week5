using System;

namespace Day1102.Riepilogo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int age;    //dichiarazione
            age = 30;   //assegnazione
            int num = 3; //inizializzazione

            const int c = 3; //costante, non posso assegnare diverso valore

            SeasonsEnum w = SeasonsEnum.winter;
            Console.WriteLine(w);

            //per vedere il valore dell'enum
            int wNum = (int)SeasonsEnum.winter;
            Console.WriteLine(wNum);

            DateTime todayDate = new DateTime(2021, 11, 02);

            //value type: non cambiano i riferimenti originali
            double l = 2.3;
            double m = l;
            m = 4; //m mi cambia valore, ma non mi cambia ANCHE l  !

            //reference type

            Book book1 = new Book();
            book1.Title = "Il nome della rosa";
            book1.Author = "Umberto Eco";

            Book book2 = new Book();
            book2 = book1; // qui sto facendo sì che i dati di book2 puntino alle stesse allocazioni di memoria di book1!
                           // se adesso modifico book2 mi va a cambiare anche quanto definito per book1

            //operazioni di boxing e unboxing...?

            int sum = Sum(22453, 324);
            Sub(2356, 448);

            int a = 5;
            Power(a);
            Console.WriteLine("Passaggio per valore: "+a);
            PowerRef(ref a);
            Console.WriteLine("Passaggio per riferimento: " + a);


        }

        enum SeasonsEnum        //fuori dal Main!
        {
            spring = 2,
            summer = 4,
            fall = 8,
            winter = 16         //posso dare la numerazione che mi pare
        }


        class Book
        {
            public string Title { get; set; } //proprietà
            public string Author { get; set; }
        }

        private static int Sum(int a, int b)
        {
            int sum;
            return sum = a + b;
        }

        private static void Sub(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        private static void Power(int a)
        {
            a *= a;
        }

        private static void PowerRef(ref int a)
        {
            a *= a;
        }
    }
}


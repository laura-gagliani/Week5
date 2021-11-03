using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1103.EsDistributoreSnack
{
    class Menu
    {
        internal static void Start()
        {

            BuySnack();

            //bool quit = false;
            //do
            //{
            ////    //Console.WriteLine("Premi 1 per aggiungere snack al distributore");
            ////    Console.WriteLine("Premi 2 per acquistare uno snack");

            //    char choice;
            //    do
            //    {
            //        Console.WriteLine("Seleziona dal menu:");
            //        choice = Console.ReadKey().KeyChar;
            //    } while (choice == '1' || choice == '2' || choice == '0');


            //    switch (choice)
            //    {
            //        //case '1':
            //        //    AddSnack();
            //        //    break;
            //        case '2':
            //            BuySnack();
            //            break;
            //        case '0':
            //            quit = true;
            //            Console.WriteLine("Chiusura in corso...");
            //            break;
            //    }
            //} while (!quit);




        }

        private static void BuySnack()
        {
            SnackManager.PrintSnacks(SnackManager.snacksDispenser);

            Snack chosenSnack = GetChosenSnack();
            while (chosenSnack == null)
            {
                Console.WriteLine("\nLo snack selezionato non è disponibile! Premi di nuovo:");
                chosenSnack = GetChosenSnack();

            }
            
            
            double payment = GetPayment() ;
           
            while (payment < chosenSnack.Price)
            {
                Console.WriteLine("Somma insufficiente! Inserisci un'altra moneta:");
                payment += GetPayment();
            }

            Console.WriteLine($"\nHai inserito {payment} euro");

            if (payment == chosenSnack.Price)
            {
                Console.WriteLine("\nErogazione dello snack...");
            }

            else
            {
                Console.WriteLine("\nErogazione dello snack...");
                Console.WriteLine("Resto erogato: " + (payment - chosenSnack.Price) + " euro");
            }
        }



        private static double GetPayment()
        {
            // input danaro
            bool isPayment;
            double payment;
            do
            {
                Console.WriteLine("\nInserire moneta:");
                isPayment = double.TryParse(Console.ReadLine(), out payment);
            } while (!isPayment);

            return payment;

        }

        private static Snack GetChosenSnack()
        {
            // selezione numero

            int choice;
            bool isInt;
            do
            {
                Console.WriteLine("\nSeleziona lo snack desiderato:");
                isInt = int.TryParse(Console.ReadLine(), out choice);
            } while (!isInt);

            // recupero snack 
            //SI POTEVANO USARE I COMANDI DI DICTIONARY: DICTIONARY.CONTAINSKEY(), RETURN DICTIONARY[KEY]...

            Snack chosenSnack = new Snack();
            
            foreach (var item in SnackManager.snacksDispenser)
            {
                if (item.Key == choice)
                {
                    chosenSnack = item.Value;
                    return chosenSnack;
                }
            }

            return null;

        }

        //private static void AddSnack()
        //{
        //    // get id
        //    SnackManager.GenerateId();

        //    // get name
        //    GetName();

        //    //get price
        //    GetInput
        //    throw new NotImplementedException();
        //}
    }
}

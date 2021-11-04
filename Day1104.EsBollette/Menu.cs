using Day1104.EsBollette.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsBollette
{
    class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            do
            {
                Console.WriteLine("\n--------------- MENU ---------------");
                Console.WriteLine("Premi 1 per calcolare la nuova bolletta e aggiungerla al tuo storico");
                Console.WriteLine("Premi 2 per visualizzare il tuo storico");
                Console.WriteLine("Premi 0 per uscire");

                char choice;
                do
                {
                    Console.WriteLine("\nSeleziona dal menu:");
                    choice = Console.ReadKey().KeyChar;
                } while (!(choice == '0' || choice == '1' || choice == '2'));



                switch (choice)
                {
                    case '1':
                        CalculateBill();
                        break;
                    case '2':
                        ViewAllBills();
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '0':
                        quit = true;
                        Console.WriteLine("\nChiusura in corso...");
                        break;
                }
            } while (!quit);
        }

        private static void ViewAllBills()
        {
            bool correctCode;
            string code;
            do
            {
                correctCode = GetFiscalCode(out code);
            } while (!correctCode);

            bool isFound = GetCustomerBills()
        }

        private static void CalculateBill()
        {
            //inserimento codice fiscale
            bool correctCode;
            string code;
            do
            {
                correctCode = GetFiscalCode(out code);
            } while (!correctCode);

            bool isFound = BillManager.GetByCode(code, out Customer customer);

            if (isFound)
            {
                decimal consumption = GetConsumption();

                if (consumption > 0)
                {
                    Bill newBill = new Bill();
                    newBill.CustomerCode = code;
                    newBill.Consumption = consumption;
                    newBill.Customer = customer;
                    newBill.Amount = BillManager.CalculateAmount(newBill);

                    bool isAdded = BillManager.AddBill(newBill);
                    if (isAdded)
                    {
                        Console.WriteLine("\nRiepilogo bolletta:");
                        Console.WriteLine($"\nCodice fiscale: {newBill.CustomerCode}");
                        Console.WriteLine($"\nConsumo: {newBill.Consumption} kw");
                        Console.WriteLine($"\nImporto totale: {newBill.Amount} euro");
                    }
                    else Console.WriteLine("\nErrore nella stampa della bolletta :(");

                }
                else Console.WriteLine("\nAttenzione, il consumo energetico non può minore o uguale a 0");
                
                
            }
            else Console.WriteLine("\nErrore! Codice fiscale non in elenco");

            //inserimento consumo

            //creazione nuova bolletta
            //aggiunta a lista bollette globale
            //aggiunta a lista bollette cliente


        }

        private static decimal GetConsumption()
        {
            bool isParsed;
            decimal consumption;
            do
            {
                Console.WriteLine("\nInserisci il tuo consumo energetico:");
                isParsed = decimal.TryParse(Console.ReadLine(), out consumption);
            } while (!isParsed);

            return consumption;
        }

        private static bool GetFiscalCode(out string code)
        {
            Console.WriteLine("\nInserisci il tuo codice fiscale:");
            code = Console.ReadLine();

            if (code != null) return true;
            else return false;
        }
    }
}


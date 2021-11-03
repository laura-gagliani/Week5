using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1102.EsErboristeria
{
    public static class Menu
    {

        //menu
        //recupero scelta utente

        internal static void Start()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("\n------------------------------------\n");
                Console.WriteLine("Premi 1 per stampare i dati relativi al prodotto di prezzo massimo");
                Console.WriteLine("Premi 2 per stampare i dati relativi al prodotto cercato");
                Console.WriteLine("Premi 3 per stampare tutti i prodotti della categoria prescelta");
                Console.WriteLine("Premi 4 per aggiornare il prezzo in aumento di un prodotto");
                Console.WriteLine("Premi 5 per stampare i dati relativi ai prodotti in una certa fascia di prezzo");
                //TODO
                Console.WriteLine("Premi 0 per uscire");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        PrintMaxPrice();
                        break;

                    case '2':
                        GetProductByCode(); //TODO
                        break;

                    case '3':
                        GetProductsByCategory();
                        break;

                    case '4': //TODO
                        UpdateProductPrice();
                        break;

                    case '5': 
                        GetProductsByPriceRange();
                        break;

                    case '6':
                        AddNewProduct();
                        break;



                    case '0':
                        exit = false;
                        Console.WriteLine("\nChiusura in corso...");
                        break;

                }
            } while (exit);
        }

        private static void AddNewProduct()
        {

            // get codice inserimento utente VEDI ALESSANDRA
            // il codice deve essere univoco: controllo
            string code = GetData("codice");

            Prodotto doppione = ErboristeriaManager.GetByCode();

            if (doppione != null)
            {
                Console.WriteLine("\nil codice inserito è già assegnato!");

            }
            else
            {
                //altre info del prodotto
                // string nome = getData("nome");
                // dobule prezzo = getprice();
                //etc
                //Prodotto newProduct = e ci metto tutti i dati recuperati dall'utente. COSTRUTTORE SENZA CAMPO ID!!
                //inserimento
               bool isAdded = ErboristeriaManager.AddProduct(newProduct);

                if (isAdded)
                {
                    //tutto ok
                }
                else if (!isAdded)
                {
                    //qualcosa è andato storto!
                }

            }


            throw new NotImplementedException();
        }

        private static void UpdateProductPrice()
        {
            // get product

            // insert new price

            // nel manager: update prezzo
        }

        private static void GetProductsByPriceRange()
        {
            Console.WriteLine("\nInserire gli estremi (min - max) entro cui si desidera ricercare");

            double min = double.Parse(Console.ReadLine());
            double max = double.Parse(Console.ReadLine());

            List<Prodotto> listaFiltrata = ErboristeriaManager.FilterByPriceRange(min, max, ErboristeriaManager.listaProdotti);
            foreach (var item in listaFiltrata)
            {
                ErboristeriaManager.PrintData(item);
            }

        }

        private static void GetProductsByCategory()
        {
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Premi 1 per selezionare i Cosmetici");
            Console.WriteLine("Premi 2 per selezionare gli Integratori");
            Console.WriteLine("Premi 3 per selezionare gli Infusi"); 

            int categValue = int.Parse(Console.ReadLine());
            List<Prodotto> listaFiltrata = ErboristeriaManager.FilterByCategory(categValue, ErboristeriaManager.listaProdotti);

            foreach (var item in listaFiltrata)
            {
                ErboristeriaManager.PrintData(item);
            }


        }

        private static void PrintMaxPrice()
        {

            Prodotto p = ErboristeriaManager.FindMaxPriceItem(ErboristeriaManager.listaProdotti);
            ErboristeriaManager.PrintData(p);

        }

        private static void GetProductByCode()
        {
            //recupero il codice inserito dall'utente
            //lo passo a un metodo che sta nella classe erboristeriaManager e che recupera il prodotto dalla lista tramite il codice
            throw new NotImplementedException();
        }
    }
}

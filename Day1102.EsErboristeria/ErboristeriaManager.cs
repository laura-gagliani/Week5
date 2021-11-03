using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1102.EsErboristeria
{
    public static class ErboristeriaManager //static: non ne creerò istanze
    {
        public static List<Prodotto> listaProdotti = new List<Prodotto>()
        {
            new Prodotto
            {   Id = 001,
                Codice = "COSM01",
                Nome = "Cipria Semi Matte",
                Categoria = CategoriaEnum.cosmetici,
                Prezzo = 14.89
            },
            new Prodotto {Id = 002, Codice = "COSM02", Nome = "Rossetto Bio", Categoria = CategoriaEnum.cosmetici, Prezzo = 14.90},
            new Prodotto {Id = 003, Codice = "INTEG03", Nome = "Caramelle Vitamina C ", Categoria = CategoriaEnum.integratori, Prezzo = 3.99},
            new Prodotto {Id = 004, Codice = "INTEG04", Nome = "VitaMix", Categoria = CategoriaEnum.integratori, Prezzo = 8.90},
            new Prodotto {Id = 005, Codice = "INFUS05", Nome = "Tè al gelsomino", Categoria = CategoriaEnum.infusi, Prezzo = 3.32},
            new Prodotto {Id = 006, Codice = "INFUS06", Nome = "Camomilla", Categoria = CategoriaEnum.infusi, Prezzo = 2.40},

        };


        public static void PrintData(Prodotto prodotto)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("\n" + prodotto.Nome + ", Id " + prodotto.Id + ", codice " + prodotto.Codice + ", prezzo " + prodotto.Prezzo + "€, categoria " + prodotto.Categoria);
        }

        internal static Prodotto FindMaxPriceItem(List<Prodotto> listaProdotti)
        {
            double maxPrice = 0.00;
            Prodotto prodCercato = null;
            foreach (var item in listaProdotti)
            {
                if (item.Prezzo > maxPrice)
                {
                    maxPrice = item.Prezzo;
                    prodCercato = item;
                }
            }
            return prodCercato;
        }

        internal static List<Prodotto> FilterByCategory(int categValue, List<Prodotto> listaProdotti)
        {
            List<Prodotto> listaFiltrata = new List<Prodotto>();

            foreach (var item in listaProdotti)
            {
                if ((int)item.Categoria == categValue)
                {
                    listaFiltrata.Add(item);
                }
            }

            return listaFiltrata;
        }

        internal static List<Prodotto> FilterByPriceRange(double min, double max, List<Prodotto> listaProdotti)
        {

            List<Prodotto> listaFiltrata = new List<Prodotto>();

            foreach (var item in listaProdotti)
            {
                if (item.Prezzo < max && item.Prezzo > min)
                {
                    listaFiltrata.Add(item);
                }
            }
            return listaFiltrata;
        }

        internal static bool AddProduct(object newProduct)
        {
            if (newProduct != null)
            {
                //generare id per nuovo prodotto
                int id = GenerateId();
                //assegno id al prodotto
                newProduct.Id = id;
                //aggiunta prodotto alla lista
                listaProdotti.Add(newProduct);

                return true;
            }

            return false;

        }

        private static int GenerateId()
        {
            //conto gli elementi già nella lista
            int count = listaProdotti.Count;
            int newId = 0;

            if (listaProdotti.Count != 0)
            {
                //recupero l'ultimo elemento e il suo id

                Prodotto p = listaProdotti[count - 1];  //METODO CHE NON VA BENE SE GLI ID PREESISTENTI SONO IN DISORDINE
                newId = p.Id + 1;

                //TODO: verificare che non esista già un prodotto con questo id. sì è convoluto

                //ALTERNATIVA: mi faccio una lista con tutti gli id esistenti, trovo il massimo e nuovoId = max + 1
            }

            else
            {
                newId = 1; //cioè se la lista è vuota, e quindi il primo elemento deve avere indice 1
            }
            

            //genero il nuovo id come ultimo id+1
            throw new NotImplementedException();
        }
    }
}

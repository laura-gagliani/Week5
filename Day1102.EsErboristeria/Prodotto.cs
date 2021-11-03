using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1102.EsErboristeria
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Codice { get; set; }
        public string Nome { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public double Prezzo { get; set; }



        //public Prodotto(int id, string codice, string nome, CategoriaEnum categoria, double prezzo)
        //{
        //    Id = id;
        //    Codice = codice;
        //    Nome = nome;
        //    Categoria = categoria;
        //    Prezzo = prezzo;

        //}

        public Prodotto()
        {

        }

        public Prodotto(string codice, string nome, double prezzo, CategoriaEnum categoria)
        {
            Codice = codice;
            Nome = nome;
            Prezzo = prezzo;
            Categoria = categoria;
        }
    }


    public enum CategoriaEnum
    {
        cosmetici = 1,
        integratori,
        infusi
    }
}

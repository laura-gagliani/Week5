using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1102.OOP
{
    class Person //modificatore di accesso di default: internal
    {
        string FirstName; // campo. mod accesso default: private (non accessibile fuori dalla classe)
        public string Surname;


        //proprietà in forma estesa
        private string _Nationality; //campo privato

        public string Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                _Nationality = value;
            }
        }

        //proprietà in forma ridotta
        //public int Age { get; }

        // public int Age { get; } = 25             così inizializzo la age a 25 (ma così tutte le persone avranno 25 anni....)


        public DateTime BirthDate { get; set; }
        public int Age { get; private set; } // metto età solo get E un metodo che calcola l'età a partire dalla data di nascita

        public void GetAge() //non ho bisogno di passargli il parametro perché sono nella classe, lui vede già BirthDate !!
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            Age = age;  // non me lo avrebbe fatto fare se fosse stato solo get; noi invece abbiamo messo get; private set;
                           //con il private set; la faccenda è visibile solo nella classe, quindi ci posso smanettare da qui MA non dal program
        }


        // passaggio da campo a proprietà

        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _code = "nessun codice";
                }
                else
                {
                    _code = value;
                }
            }
        }

        //Metodi

        public void PrintInfo() // un metodo che mi stampa le info delle istanze. essendo public lo posso chiamare dal program
        {
            Console.WriteLine(FirstName + " " + Surname + " " + BirthDate.ToShortDateString());
        }

        public override string ToString() //
        {
            // return base.ToString(); // metodo esposto dalla classe object ???

            return FirstName + " " + Surname + " " + BirthDate.ToShortDateString();
        }

        public Person (string firstName, string surname)
        {
            FirstName = firstName; //a proprietà di Person associo il parametro del costruttore
            Surname = surname;
        }

        public Person()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsContiBancari.Entities
{
    public class BankAccount
    {
        public int Number { get; set; } //lo metto come int: ruolo di PK (sempre meglio per la gestione)
        public decimal Balance { get; set; } = 0;

        //rel 1 a molti:
        // il bank account deve avere un utente! mettiamogli card minima 1

        public string AccountHolderCode { get; set; } // il FK ( in questo caso string - quindi nullable - ma vabbè...)

        public AccountHolder AccountHolder { get; set; } // la NAV PROPERTY

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsContiBancari.Entities
{
    public class AccountHolder
    {
        public string Code { get; set; } //PK, codice cliente. sarebbe stato "più semplice" lavorare con un int, ma mettiamo string
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // l'omino può avere anche molti conti in banca: nel suo tipo quindi ci va una collection (per ora mettiamo lista)
        // in modo da avere un collegamento ai conti a lui associati

        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

    }
}

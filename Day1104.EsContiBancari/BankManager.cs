using Day1104.EsContiBancari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsContiBancari
{
    public static class BankManager
    {
        static List<AccountHolder> accountHolders = new List<AccountHolder>() 
        {
            new AccountHolder {Code = "ABC", FirstName = "Mario", LastName = "Rossi"}
        };

        static List<BankAccount> bankAccounts = new List<BankAccount>();

        internal static AccountHolder GetByCode(string code)
        {
            foreach (AccountHolder item in accountHolders)
            {
                if (item.Code == code)
                {
                    return item;
                }
            }
            return null;
        }

        internal static bool AddBankAccount(BankAccount newBankAccount)
        {
            if (newBankAccount != null)
            {
                //devo generare il numero di conto: poteva essere incrementale +1 oppure randomico (non ordinato)
                int number = GenerateAccountNumber();

                //il numero ottenuto va associato al conto
                newBankAccount.Number = number;

                //fatto ciò metto il conto in lista: la lista di conti GENERICA, ovvero quella della banca
                bankAccounts.Add(newBankAccount);

                //e associo all'intestatario il conto (completo di tutti i dati):

                AccountHolder a = newBankAccount.AccountHolder; // l'intestatario di sto conto
                List<BankAccount> accounts = a.BankAccounts; // la lista dei conti di sto intestatario!!! NB non la lista di conti "generica"
                accounts.Add(newBankAccount); //aggiungo il conto alla lista

                //SCORCIATO POTEVA ESSERE SCRITTO COSI:
                //newBankAccount.AccountHolder.BankAccounts.Add(newBankAccount);

                return true;
            }
            return false;


        }

        private static int GenerateAccountNumber() //me lo crea private: in effetti è probabile che io non chiamerò questo metodo dal menu!
        {
            int count = bankAccounts.Count;
            int newNumberAccount;
            if (count > 0)
            {
                int lastNumberAccount = bankAccounts[count - 1].Number; // l'ultimo indice usato
                newNumberAccount = lastNumberAccount + 1;

            }
            else
            {
                newNumberAccount = 1;
            }

            return newNumberAccount;
        }

        internal static bool UpdateAccount(BankAccount account)
        {
            if (account != null)
                return true;

            else
                return false;
        }

        internal static BankAccount GetByAccountNumber(int number)
        {
            foreach (var item in bankAccounts)
            {
                if (item.Number == number)
                {
                    return item;
                }
                
            }
            return null;
        }

        internal static bool AddAccountHolder(AccountHolder newAccountHolder)
        {
            if (newAccountHolder != null)
            {
                string code = GenerateHolderCode();
                //controllo code ripetuto

                bool isRepeated = CheckCodeRepeats(code);
                while (isRepeated)
                {
                    code = GenerateHolderCode();
                    isRepeated = CheckCodeRepeats(code);
                }
                

                newAccountHolder.Code = code;

                accountHolders.Add(newAccountHolder);

                return true;
            }

            return false;
        }

        private static bool CheckCodeRepeats(string code)
        {
            bool isRepeated;
            foreach (var item in accountHolders) //alessandra ha controllato con un while (GetByCode(code) != null), ovvero frulla finché continui a trovare quel codice già nel DB
            {
                if (item.Code == code)
                {
                    return isRepeated = true;
                }

            }
            return isRepeated = false;
        }

        private static string GenerateHolderCode()
        {
            Random rndGen = new Random();
            int length = 5;
            string rndCode = "";
            for (int i = 0; i < length; i++)
            {
                rndCode += ((char)(rndGen.Next(1, 26) + 64)).ToString().ToUpper();
            }

            return rndCode;
        }
    }
}

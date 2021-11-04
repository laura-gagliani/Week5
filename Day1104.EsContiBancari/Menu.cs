using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1104.EsContiBancari.Entities
{
    public static class Menu
    {
        internal static void Start()
        {


            bool quit = false;
            do
            {
                Console.WriteLine("\n--------------- MENU ---------------");
                Console.WriteLine("Premi 1 per aggiungere un nuovo conto");
                Console.WriteLine("Premi 2 per gestire prelievi"); //rimozione di soldi
                Console.WriteLine("Premi 3 per gestire versamenti"); //aggiunta di soldi: usano Get
                Console.WriteLine("Premi 4 per visualizzare saldo");
                Console.WriteLine("Premi 5 per chiudere un conto"); //eliminazione
                Console.WriteLine("Premi 0 per uscire");

                char choice;
                do
                {
                    Console.WriteLine("\nSeleziona dal menu:");
                    choice = Console.ReadKey().KeyChar;
                } while (!(choice == '0' || choice == '1' || choice == '2' || choice == '3' || choice == '4' || choice == '5'));

                

                switch (choice)
                {
                    case '1':
                        AddNewBankAccount();
                        break;
                    case '2':
                        WithdrawFromAccount();
                        break;
                    case '3':
                        PayIntoAccount();
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

        private static void WithdrawFromAccount()
        {
            int number;
            do
            {
                Console.WriteLine("\nInserisci il numero di conto:");
            } while (!int.TryParse(Console.ReadLine(), out number));

            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                //recupero importo versamento
                decimal amount = GetAmount("prelevare");

                if (amount > account.Balance)
                {
                    Console.WriteLine("\nImpossibile prelevare una somma maggiore del saldo attuale!");
                }

                else
                {
                    account.Balance -= amount;

                    bool isUpdated = BankManager.UpdateAccount(account);

                    if (isUpdated)
                    {
                        Console.WriteLine($"\nIl nuovo saldo è pari a {account.Balance} euro");
                    }
                }
                

            }
            else
            {
                Console.WriteLine("\nNon esiste alcun conto con questo numero");
            }

        }

        private static void PayIntoAccount()
        {
            int number;
            do
            {
                Console.WriteLine("\nInserisci il numero di conto:");
            } while (!int.TryParse(Console.ReadLine(), out number));

            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                //recupero importo versamento
                decimal amount = GetAmount("versare");

                account.Balance += amount;  //<- se non ci spostiamo nel manager

                bool isUpdated = BankManager.UpdateAccount(account);

                if (isUpdated)
                {
                    Console.WriteLine($"\nIl nuovo saldo è pari a {account.Balance} euro");
                }

            }
            else
            {
                Console.WriteLine("\nNon esiste alcun conto con questo numero");
            }
        }

        

        private static void AddNewBankAccount()
        {
            char choice;
            string code;
            do
            {
                Console.WriteLine("\nL'utente è già cliente? y/n");
                choice = Console.ReadKey().KeyChar;

            } while (!(choice == 'y' || choice == 'n'));

            if (choice == 'n')
            {
                //richiesta Nome, Cognome: dati cliente
                string firstName = GetData("nome");
                string lastName = GetData("cognome");

                // new cliente con quei dati lì
                AccountHolder newAccountHolder = new AccountHolder();
                newAccountHolder.FirstName = firstName;
                newAccountHolder.LastName = lastName;

                //aggiunta new cliente alla lista: metodo che richiede generazione di un codice stringa
                bool holderIsAdded = BankManager.AddAccountHolder(newAccountHolder);

                if (holderIsAdded)
                {
                    Console.WriteLine($"Cliente aggiunto con successo, codice cliente {newAccountHolder.Code}");
                }
                else
                {
                    Console.WriteLine("Errore nell'inserimento del nuovo cliente");
                }

            }
            //a questo punto il cliente c'è, o preesistente o appena inserito

            code = GetData("codice cliente");

            //controllo che effettivamente sia cliente: guardo nella collection clienti
            AccountHolder accountHolder = BankManager.GetByCode(code);

            if (accountHolder == null)
            {
                Console.WriteLine("\nNon esiste cliente con questo codice!");
            }
            else //codice cliente trovato, tutto ok
            {
                // creo nuovo conto:
                // vi associo il codice cliente (FK + nav property)
                // gli altri due campi: la PK gliela facciamo generare automaticamente, il saldo è inizializzato a zero

                BankAccount newBankAccount = new BankAccount();
                newBankAccount.AccountHolder = accountHolder; //popolo la nav prop
                newBankAccount.AccountHolderCode = accountHolder.Code; // popolo la FK

                //ora ho i dati necessari! passo il tutto ad un metodo che crei il conto generandone il codice
                bool accountIsAdded = BankManager.AddBankAccount(newBankAccount);

                if (accountIsAdded)
                {
                    Console.WriteLine($"Conto aggiunto con numero {newBankAccount.Number}, intestatario {newBankAccount.AccountHolder.FirstName} {newBankAccount.AccountHolder.LastName}");
                }

                else
                {
                    Console.WriteLine("Errore nell'aggiunta di un nuovo conto");
                }
                #region copia originale del case 1
                //switch (choice)
                //{
                //    case 'y':
                //        //già cliente -> ne recupero il codice
                //        code = GetData("codice cliente");

                //        //controllo che effettivamente sia cliente: guardo nella collection clienti
                //        AccountHolder accountHolder = BankManager.GetByCode(code);

                //        if (accountHolder == null)
                //        {
                //            //non posso procedere! non c'è il cliente
                //            Console.WriteLine("\nNon esiste cliente con questo codice!");
                //        }
                //        else
                //        {
                //            //ok! procedo con aggiunta conto
                //            // creo nuovo conto:
                //            // vi associo il codice cliente (FK + nav property)
                //            // gli altri due campi: la PK gliela facciamo generare automaticamente, il saldo è inizializzato a zero

                //            BankAccount newBankAccount = new BankAccount();
                //            newBankAccount.AccountHolder = accountHolder; //popolo la nav prop
                //            newBankAccount.AccountHolderCode = accountHolder.Code; // popolo la FK

                //            //ora ho i dati necessari! passo il tutto ad un metodo che crei il conto generandone il codice
                //            //lo facciamo fare alla classe BankManager

                //            bool accountIsAdded = BankManager.AddBankAccount(newBankAccount);

                //            if (accountIsAdded)
                //            {
                //                Console.WriteLine($"Conto aggiunto con numero {newBankAccount.Number}, intestatario {newBankAccount.AccountHolder.LastName}");
                //            }

                //            else
                //            {
                //                Console.WriteLine("Errore");
                //            }

                //        }


                //        break;
                //    case 'n':
                //        //no cliente

                //        // richiesta Nome, Cognome: dati cliente
                //        string firstName = GetData("nome");
                //        string lastName = GetData("cognome");

                //        // new cliente con quei dati lì
                //        AccountHolder newAccountHolder = new AccountHolder();
                //        newAccountHolder.FirstName = firstName;
                //        newAccountHolder.LastName = lastName;

                //        // aggiunta new cliente alla lista: metodo che richiede generazione di un codice stringa
                //        // codice random con? numeri lettere ?
                //        bool holderIsAdded = BankManager.AddAccountHolder(newAccountHolder);

                //        if (holderIsAdded)
                //        {
                //            Console.WriteLine("Cliente aggiunto con successo");
                //        }
                //        else
                //        {
                //            Console.WriteLine("Errore nell'inserimento del nuovo cliente");
                //        }
                //        //sul cliente devo creare un nuovo conto: riuso tutto il meccanismo di prima
                //         break;

                //}
                #endregion
            }


        }

        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.WriteLine($"\nInserisci il {value} del cliente");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }
        private static decimal GetAmount(string value)
        {
            decimal amount;
            do
            {
                Console.WriteLine($"\nInserisci l'importo da {value}:");

            } while (!decimal.TryParse(Console.ReadLine(), out amount));

            return amount;
        }
    }
}

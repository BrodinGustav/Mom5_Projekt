using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class BudgetManager
    {
        //Deklarerar privat variabel SaveData för åtkomst till spara/ladda data-metoder
        private SaveData _saveData;


        //Initierar Lista av transaktioner
        private List<Transaction> _transactionList = new List<Transaction>();


        //Konstruktor
        public BudgetManager(SaveData saveData, string filePath)
        {
            //Initierar SaveData. Kastar exception ifall null
            _saveData = saveData ?? throw new ArgumentNullException(nameof(saveData), "SaveData kan inte vara null");

            try
            {
                //Laddar transaktioner från JSON-filen vid start
                _transactionList = _saveData.LoadTransaction(filePath) ?? new List<Transaction>();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid laddning av transaktioner: {ex.Message}");

                //Skapar tom lista om fel vid laddning
                _transactionList = new List<Transaction>();
            }
        }




        //Metod för att registrera transaktion
        public void addTransaction(TransactionType type, string category, string description, decimal amount, DateTime date)
        {

            try

            {
                //Kontroll om input är korrekt
                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Var god ange kategori.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Var god ange beskrivning.");
                    return;
                }

                //Kontroll om input är under 0
                if (amount <= 0)
                {
                    Console.WriteLine("Var god ange ett giltigt belopp större än 0.");
                    return;
                }

                else
                {
                    //Skapar ny transaktion
                    Transaction newTransaction = new Transaction(type, category, description, amount, date);

                    //Lägger till transaktionen till listan 
                    _transactionList.Add(newTransaction);

                    try
                    {
                        //Anropar metod för att spara transaktion. Skickar med listan
                        _saveData.SaveTransaction(_transactionList);

                        //Laddar om listan från JSON
                        _saveData.LoadTransaction("budgetData.json");


                        //Anropar metod för utskrift
                        newTransaction.DisplayInfo();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ett fel inträffade vid sparande av transaktionen: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett fel inträffade vid tillägg av transaktionen: " + ex.Message);
            }
        }




        //Metod för att skriva ut transaktioner
        public void displayTransactions()
        {
            try
            {

                //Kontroll om JSON innehåller data
                if (_transactionList == null || !_transactionList.Any())
                {
                    Console.WriteLine("Det finns inga transaktioner att visa");
                    return;
                }

                //Loopar igenom data och skriver ut varje transaktion 
                for (int i = 0; i < _transactionList.Count; i++)
                {
                    //Lagrar varje index i variabel
                    var transaction = _transactionList[i];

                    //Tilldelar ID till varje transaktion, samt anropar DisplayInfo från basklassen gällande utskrift
                    Console.WriteLine($"ID: [{i + 1}] - {transaction.DisplayInfo()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett fel inträffade vid visning av transaktioner: " + ex.Message);
            }
        }




        //Metod för att radera transaktion
        public void deleteTransaction(int index)
        {
            try
            {
                
                //Kontroll om JSON-fil innehåller data
                if (_transactionList == null || _transactionList.Count == 0)
                {
                    Console.WriteLine("Finns inga transaktioner att radera");
                    return;
                }


                //Kontroll om medskickat index är inom ramen för listan
                if (index < 0 || index > _transactionList.Count)
                {
                    Console.WriteLine("Ogiltigt index. Var god försök igen.");
                    return;
                }

                //Radera transaktion
                _transactionList.RemoveAt(index);

                Console.WriteLine("Transaktion har raderats.");

                try
                {
                    //Sparar uppdaterad lista
                    _saveData.SaveTransaction(_transactionList);

                    //Laddar om listan från JSON
                    _saveData.LoadTransaction("budgetData.json");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel inträffade vid sparning efter raderad transaktion: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett fel inträffade vid radering av transaktion: " + ex.Message);
            }
        }




        //Metod som räknar ut totalt saldo
        public decimal CalculateBalance()
        {
            try
            {

                //Deklarerar variabler som håller totala värden för inkomst/utgift
                decimal totalIncome = 0;
                decimal totalExpense = 0;

                //Lagrar sparad JSON-data i variabel                        
                var balance = _transactionList;

                //Loopar igenom transaktionerna i listan från JSON
                foreach (var transaction in balance)
                {
                    //Kontroll med Enum om transaktion är inkomst
                    if (transaction.Type == TransactionType.Income)
                    {
                        //Inkomstens summa läggs till den totala summan
                        totalIncome += transaction.Amount;
                    }

                    //Kontoll med Enum om transaktion är utgift.
                    else if (transaction.Type == TransactionType.Expense)
                    {
                        //Utgiftens summa läggs till totala summan
                        totalExpense += transaction.Amount;
                    }
                }

                //Returnerar summan av subtrationen mellan Inkomst och Utgifter    
                return totalIncome - totalExpense;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett fel inträffade vid beräkning av saldo: " + ex.Message);
                return 0;
            }
        }



        //Metod som randomiserar procentuell slumpmässig ökning för utgifter
        public void TestBudget()
        {
            try
            {
                //Anropar randomiseraren. Skickar med BudgetManager-instansen.
                Randomiserare.GenerateRandomExpense(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid test av budget: {ex.Message}");

            }

        }


        //Metod för att hämta transaktioner. Används för Randomiserar-klassen.
        public List<Transaction> GetTransactions()
        {
            try
            {
                //Returnerar den laddade listan av transaktioner
                return _transactionList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid hämtning av transaktioner:  {ex.Message}");
            }
            return new List<Transaction>();
        }

    }

}


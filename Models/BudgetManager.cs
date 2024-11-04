using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class BudgetManager
    {
        //Deklarerar privat variabel SaveData för åtkomst till spara/ladda data-metoder
       private SaveData _saveData;



        //Initierar Lista
       private List<Transaction> _transactionList = new List<Transaction>();




    //Tar emot SaveData som argument i konstruktorn
    public BudgetManager(SaveData saveData)
    {
        //Initierar
        _saveData = saveData;
         _transactionList = new List<Transaction>();
    }
    



       //Anropar metod från klassen SaveData för att läsa in sparade transaktioner
        public void LoadTransaction()
        {
            _transactionList =_saveData.LoadTransaction();


            if (_transactionList != null && _transactionList.Count > 0)
            {
                Console.WriteLine("Transaktioner har laddats");
            }


            else
            {
                Console.WriteLine("Inga transaktioner hittades");
            }

        }
    

    

            //Metod för att registrera transaktion
            public void addTransaction(string category, string description, decimal amount, DateTime date)
           {   

            try

            {
                //Kontroll om input är korrekt
                  if(string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(description)) //Hur göra med kontroll för int och date?
            {
                
                Console.WriteLine("Var god ange kateogiry och beskrivning");
                return;
            
            }

            if (amount <= 0)
        {
            Console.WriteLine("Var god ange ett giltigt belopp (större än 0).");
            return;
        }


            else
            {
                //Skapar ny transaktion
                Transaction newTransaction = new Transaction(category, description, amount, date);

      // Lägger till transaktionen till listan i SaveData
        _saveData._transactionList.Add(newTransaction); // Använd Transaction direkt här


                // Anropar metod från SaveData för att spara transaktion. Skickar med listan
        if (_saveData._transactionList.Count > 0)
        {
            _saveData.SaveTransaction(_saveData._transactionList);
             
              
                //Anropar metod för utskrift
                newTransaction.DisplayInfo();
            }
        
            else
            {
                Console.WriteLine("Det finns inga transaktioner att spara.");
            }   
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ett fel inträffade: " + ex.Message);
            }
        }
           



            //Metod för att skriva ut transaktioner
            public void displayTransactions()
            {
                var transactionList = _saveData.LoadTransaction();

               if (transactionList.Count > 0)
                {
                    
                    for(int i = 0; i < transactionList.Count; i++)
                    {
                        var transaction = transactionList[i];
                        Console.WriteLine($"ID: [{i+1}] - {transaction.DisplayInfo()}");
                    }
                    
                    
                 
                }
            }

            //Metod för att radera transaktion
            public void deleteTransaction (int index)
            {
                  var transactionList = _saveData.LoadTransaction();
                
                if (transactionList == null  || transactionList.Count == 0)
                {
                    Console.WriteLine("Finns inga transaktioner att radera");
                    return;
                }
                
                
                //Kontroll om index är inom ramen för listan
                if (index >= 0 && index < transactionList.Count)
                {
                    //Radera transaktion
                    transactionList.RemoveAt(index);

                    //Sparar uppdaterad lista
                    _saveData.SaveTransaction(_transactionList);
                    Console.WriteLine("Transaktion har raderats.");
                }
                else
                {
                    Console.WriteLine("Det finns inga transaktioner att radera.");
                }
            }
    }

    }

 
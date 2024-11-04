using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

        //Laddar transaktioner från JSON-filen vid start
        _transactionList = _saveData.LoadTransaction() ?? new List<Transaction>();
    

    
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

                //Lägger till transaktionen till listan i SaveData
                _transactionList.Add(newTransaction); // Använd Transaction direkt här


                // Anropar metod från SaveData för att spara transaktion. Skickar med listan
                if (_transactionList.Count > 0)
                {
                    _saveData.SaveTransaction(_transactionList);
             
              
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
           
                //Kontroll om JSON innehåller data
               if (_transactionList.Count > 0)
                {
                    //Loopar igenom data och skriver ut varje transaktion 
                    for(int i = 0; i < _transactionList.Count; i++)
                    {
                        var transaction = _transactionList[i];

                        //Tilldelar ID till varje transaktion, samt anropar DisplayInfo från basklassen gällande utskrift
                        Console.WriteLine($"ID: [{i+1}] - {transaction.DisplayInfo()}");
                    }
                    
                    
                 
                }
            }

            //Metod för att radera transaktion
            public void deleteTransaction (int index)
            {

                //Kontroll om JSON-fil innehåller data
                if (_transactionList == null  || _transactionList.Count == 0)
                {
                    Console.WriteLine("Finns inga transaktioner att radera");
                    return;
                }


                //Kontroll om medskickat index är inom ramen för listan
                if (index >= 0 && index < _transactionList.Count)
                {
                    //Radera transaktion
                    _transactionList.RemoveAt(index);

                    //Sparar uppdaterad lista
                    Console.WriteLine("Transaktion har raderats.");
                    _saveData.SaveTransaction(_transactionList);
            
                }
                else
                {
                    Console.WriteLine("Ogiltigt index. Var god försök igen.");
                    return;
                }
            }
    }

    }

 
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
       private List<TransactionBluePrint> _transactionBluePrintList = new List<TransactionBluePrint>();




    //Tar emot SaveData som argument i konstruktorn
    public BudgetManager(SaveData saveData)
    {
        _saveData = saveData;
         _transactionBluePrintList = new List<TransactionBluePrint>();
    }
    



       //Anropar metod från klassen SaveData för att läsa in sparade transaktioner
     /*   public void LoadTransaction()
        {
            _transactionBluePrintList =_saveData.LoadTransaction();


            if (_transactionBluePrintList != null && _transactionBluePrintList.Count > 0)
            {
                Console.WriteLine("Transaktioner har laddats");
            }


            else
            {
                Console.WriteLine("Inga transaktioner hittades");
            }

        }*/
    

    

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

            else
            {
                //Skapar ny transaktion
                Transaction newTransacion = new Transaction(category, description, amount, date);


                //Lägger till transaktion till listan
              _transactionBluePrintList.Add(newTransacion);


                //Anropar metod från SaveData för att spara transaktion. Skickar med listan
                if (_transactionBluePrintList != null && _transactionBluePrintList.Count > 0)
            {
                _saveData.SaveTransaction(_transactionBluePrintList);
    
                //Anropar metod för utskrift
                newTransacion.DisplayInfo();
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

    }

    }

 
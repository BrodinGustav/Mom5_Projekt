using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class BudgetManager
    {

        //Deklarerar lista utifrån basklassen TransactionBluePrint som lagrar transaktioner
        public List<TransactionBluePrint> _transactionBluePrintList { get; private set; }

        //Deklarerar privat variabel SaveData för åtkomst till spara/ladda data-metoder
       private SaveData _saveData;
       

    //Tar emot SaveData som argument i konstruktorn
    public BudgetManager(SaveData saveData)
    {
        _saveData = saveData;
     
    }

       //Anropar metod från klassen SaveData för att läsa in sparade transaktioner
        public void LoadTransaction()
        {
            _saveData.LoadTransaction();
        }
    

            //Metod för att registrera transaktion
            public void addTransaction(string category, string description, decimal amount, DateTime date)
           {   
                //Kontroll om input är korrekt
                  if(string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(description)) //Hur göra med kontroll för int och date?
            {
                
                Console.WriteLine("Var god ange kateogiry och beskrivning");
            
            }
            else
            {
                //Skapar objekt
                TransactionBluePrint newTransaction = new Transaction(category, description, amount, date);

                //Lägger till transaktion till listan genom anrop till SaveData-klassen
              _transactionBluePrintList.Add(newTransaction);

                //Anropar metod från SaveData för att spara transaktion. Skickar med listan
                _saveData.SaveTransaction(_transactionBluePrintList);
            }

            //Metod för att skriva ut transaktioner

            //Metod för att radera transaktion

    }

    }
}
 
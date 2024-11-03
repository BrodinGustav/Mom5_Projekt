using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Mom5_Projekt.Models
{
   
       public class SaveData
    {
         //Instansierar BudgetManager 
        BudgetManager budgetManager= new BudgetManager();


        //Metod för att spara transaktion
        public void SaveTransaction()
        {
            //Serialiserar listan till JSON-sträng.
            string json = JsonSerializer.Serialize(budgetManager._transactionBluePrintList);

            //Skriver över Json-sträng till fil
            File.WriteAllText("budgetData.json", json);
        }        




        //Metod för att ladda sparad transaktion
        public int LoadTransaction()
        {
            //Lagrar json-fil i variabel
            string fileName = "budgetData.json";

            //Variabel för räknar transaktioner
            int transactionCount = 0;

            //Kontroll om filen finns
            if(File.Exists(fileName))
            {
                //Läser in filen som sträng
                string jsonText = File.ReadAllText(fileName);

                //Deserialiserar JSON-sträng till lista av objekt
                budgetManager._transactionBluePrintList = JsonSerializer.Deserialize<List<TransactionBluePrint>>(jsonText);

                //Hämta antalet transaktioner
                transactionCount = budgetManager._transactionBluePrintList.Count;
            }
            else
            {
                Console.WriteLine("Inga transaktioner hittades.");
            }
                //returnerar antal transaktioner
                return transactionCount;
        }
    }

}
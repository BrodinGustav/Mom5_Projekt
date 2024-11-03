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

            //Deklarerar lista utifrån basklassen TransactionBluePrint som lagrar transaktioner
            public List<TransactionBluePrint> _transactionBluePrintList { get; set; }




        //Metod för att spara transaktion
        public void SaveTransaction(List<TransactionBluePrint> transactions)
        {
            //Serialiserar listan till JSON-sträng.
            string json = JsonSerializer.Serialize(transactions);

            //Skriver över Json-sträng till fil
            File.WriteAllText("budgetData.json", json);
        }        




        //Metod för att ladda sparad transaktion
        public List <TransactionBluePrint> LoadTransaction()
        {
            //Lagrar json-fil i variabel
            string fileName = "budgetData.json";

            //Kontroll om filen finns
            if(File.Exists(fileName))
            {
                //Läser in filen som sträng
                string jsonText = File.ReadAllText(fileName);

                //Deserialiserar JSON-sträng till lista av objekt
                return JsonSerializer.Deserialize<List<TransactionBluePrint>>(jsonText) ?? new List<TransactionBluePrint>();;

              
            }
            else
            {
                Console.WriteLine("Inga transaktioner hittades.");
                 return new List<TransactionBluePrint>();
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class TransactionCategory
    {
              private Dictionary<string, List<Transaction>> _categories = new Dictionary<string, List<Transaction>>();
            
            // Instans för att spara data
            private SaveData _saveData = new SaveData(); 
            
            // Sökväg 
            private string _filePath; 
    

    //Metod som lagrar sökvägen till variabel
      public TransactionCategory(string filePath)
    {
        _filePath = filePath;
    }
    
    
      //Metod för att returnera en kopia av _categories. Görs för att ge tillgång till Dictionary för saveData
      public Dictionary<string, List<Transaction>> GetCategoriesCopy()
      {
        return new Dictionary<string, List<Transaction>>(_categories);
      }


        //Metod för att registrera transaktion
        public void AddTransaction (string category, Transaction transaction)
        {
            //Kontroll om kategorin finns
            if(!_categories.ContainsKey(category))
            {
                //Om inte, skapa en ny lista med transaktioner för registrerad kategori
                _categories[category] = new List<Transaction>();
            }
                //Lägg till transaktioner till kategorin
                _categories[category].Add(transaction);

                //Sparar uppdaterade data direkt efter att transaktionen lagts till
                _saveData.saveBudget(this, _filePath);
        
        }
    
       


        //Metod för att radera transaktion


        //Metod för att hämta transaktioner
        public List<Transaction> FetchTransactions(string category)
        {
           
                   return _categories.ContainsKey(category) ? _categories[category] : new List<Transaction>();
           
        }
        
    
    
    }
}
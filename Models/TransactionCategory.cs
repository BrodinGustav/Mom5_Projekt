using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class TransactionCategory
    {
              private Dictionary<string, List<Transaction>> _categories = new Dictionary<string, List<Transaction>>();
    
    
    
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
        }
    
        //Metod för att radera transaktion


        //Metod för att hämta transaktioner
        public List<Transaction> FetchTransactions(string category)
        {
           
                   return _categories.ContainsKey(category) ? _categories[category] : new List<Transaction>();
           
        }
        
    
    }
}
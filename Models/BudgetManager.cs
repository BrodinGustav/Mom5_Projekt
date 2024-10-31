using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class BudgetManager
    {
        //Privat medlemsvariabel för TransactionCategory
         private TransactionCategory _transactionCategory;
    
    //Konstruktor
    public BudgetManager()
    {
                //Instansierar TransactionCategory
                _transactionCategory = new TransactionCategory();
    }

    //Metoder

    //Metod för registrering av transaktion
    public void RegisterTransaction(string category, Transaction transaction)
    {
        //Anropar AddTransaction från TransactionCategory
        _transactionCategory.AddTransaction(category, transaction);

        Console.WriteLine($"Transaktion för kategorin: {category} är registrerad");
    }
 
 
    }
}
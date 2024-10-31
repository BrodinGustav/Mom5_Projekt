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

         private Transaction _transaction;
    
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
 
    //Metod för att hämta transaktioner
    public void GetTransactions(string category)
    {
        var transactions = _transactionCategory.FetchTransactions(category);

        if (transactions !=null && transactions.Count > 0)
        {
            Console.WriteLine($"Transaktioner för kateogin: {category} ");
            Console.WriteLine("-----------------------------------------");

            foreach (var _transaction in transactions)
            {
                _transaction.DisplayInfo();

               // Console.WriteLine($"ID: {transaction.TransactionID}, Beskrivning: {transaction.Description}, Belopp: {transaction.Amount}, Datum: {transaction.Date}");
            }
        }
           else
    {
        Console.WriteLine($"Inga transaktioner hittades för kategorin '{category}'.");
    }
    }


    }
}
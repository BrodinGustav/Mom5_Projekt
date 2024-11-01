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

         //Privat medlemsvariabel för Transaction
         private Transaction _transaction;

        //Privat medlemsvariabel för SaveData
         private SaveData _saveData;



//Sökväg till JSON-fil där data ska sparas
string filePath= @"C:\Utbildning\DT071G C#.NET\Mom5_Rapport\Nytt försök\budgetData.json";


         
    
    //Konstruktor
    public BudgetManager()
    {
              _transactionCategory = new TransactionCategory(filePath);
            _saveData = new SaveData();
       

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
        _saveData.LoadDataFromFile(filePath, _transactionCategory);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
        //Klassen ärver från basklassen Transaction
    public class Transaction : TransactionBluePrint
    {

        //Konstruktor
        public Transaction(string category, string description, decimal amount, DateTime date) :base(category, description, amount, date)
        {
            
        }

        //Metoder att ärva från TransactionBluePrint
      public override string DisplayInfo()
        {
            return $"[Inkomst], Kategori: {Category}, Beskrivning: {Description}, Belopp: {Amount}, Datum: {Date.ToShortDateString()}";
        }
    
    
    
    
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
        //Klassen ärver från basklassen Transaction
    public class Transaction : TransactionBluePrint
    {
        public TransactionType Type { get; set; }   

        //Konstruktor
        public Transaction(TransactionType type, string category, string description, decimal amount, DateTime date) :base(category, description, amount, date)
        {
            Type = type;
        }

        //Metoder att ärva från TransactionBluePrint
      public override string DisplayInfo()
        {
            return $"[{Type}], Kategori: {Category}, Beskrivning: {Description}, Belopp: {Amount}, Datum: {Date.ToShortDateString()}";
        }
    
    
    
    
    }

}
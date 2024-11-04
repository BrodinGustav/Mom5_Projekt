using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public abstract class TransactionBluePrint
    {
        //private set används för att kaplsa in datan i klassen. 
        public string Category { get; private set; }
        public string Description   { get; private set; }
        public decimal Amount { get; private set; } 
        public DateTime Date   { get; private set; } 

        //Konstruktor
        public TransactionBluePrint (string category, string description, decimal amount, DateTime date)
        {
            Category = category;
            Description = description;
            Amount = amount;
            Date = date;
        }  

  //Metod för att uppdatera Amount
    protected void SetAmount(decimal amount)
    {
        Amount = amount;
    }

        //Metoder
        public virtual string DisplayInfo()
        {
            return $"Kategori: {Category}, Beskrivning: {Description}, Belopp: {Amount}, Datum: {Date.ToShortDateString()}";
        }
    
}
}
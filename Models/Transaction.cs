using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public abstract class Transaction
    {
        //private set används för att kaplsa in datan i klassen. 
        public int TransactionID { get; private set; }
        public string Description   { get; private set; }
        public decimal Amount { get; private set; } 
        public DateTime Date   { get; private set; } 

        //Konstruktor
        public Transaction (string description, decimal amount, DateTime date)
        {
            Description = description;
            Amount = amount;
            Date = date;
        }  

        //Metoder
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {TransactionID}, Beskrivning: {Description}, Belopp: {Amount}, Datum: {Date.ToShortDateString()}");
        }
    
        //Boolean som kollar ifall transaktion är inkomst eller utkomst
        public abstract bool isIncome();
}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    //Klassen ärver från basklassen Transaction
    public class Expense: Transaction
    {
        //Konstruktor
        public Expense(string description, decimal amount, DateTime date) : base (description, amount, date)
        {
        }

         //Metoder

        //Implementerar abstrakt metod
        public override bool isIncome() => false;

        //Ärvar metod DisplayInfo() för att anpassa visning
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Utgift] {Description}: - {Amount} kr, Datum {Date.ToShortDateString()}");
        }

        
    }
}
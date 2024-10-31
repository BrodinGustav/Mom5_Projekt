using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
        //Klassen ärver från basklassen Transaction
    public class Income: Transaction
    {
        //Konstruktor
        public Income(string description, decimal amount, DateTime date) : base (description, amount, date)
    
    {
}

        //Implementerar abstrakt metod
        public override bool isIncome() => true;

        //Ärver DisplayInfo för att anpassa visning
        public override void DisplayInfo()
        {
           Console.WriteLine($"[Inkomst] {Description}: + {Amount}: kr, Datum: {Date.ToShortDateString()}");
        }   



    }
}
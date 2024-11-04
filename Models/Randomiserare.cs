using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{

    public class Randomiserare
    {
        //Initierar statiskt objekt av randomiserare
        private static Random random = new Random();

        //Metod för slumpmässiga utgifter
        public static void GenerateRandomExpense(BudgetManager budgetManager)
        {

            //Ladda befintlig data
            var transactions = budgetManager.GetTransactions();

            //Kontroll om data existerar
            if (transactions == null || !transactions.Any())
            {
                Console.WriteLine("Ingen data att bearbeta.");
                return;
            }

            decimal totalIncome = 0; // För att hålla reda på den totala inkomsten
            decimal totalExpenses = 0; // För att hålla reda på totala utgifter

            //Uppdatera kategorier och transaktioner i CategorizedTransactions
            foreach (var transaction in transactions)
            {

              //Kontroll om transaktionen är en utgift
                if (transaction.Type == TransactionType.Expense)
                {
                        //Applicera slumpmässig procentuell ökning upp till 50%
                        decimal percentageIncrease = 1 + (decimal)(random.NextDouble() * 0.50);

                        //Lagrar nytt Amount i variabel
                        decimal newAmount = Math.Round(transaction.Amount * percentageIncrease, 2);

                        //Anropar metod med newAmount
                        transaction.UpdateTransaction(newAmount);

                        // Skriv ut den ökade utgiftstransaktionen
                        Console.WriteLine($"[Beskrivning]: {transaction.Description}, Nytt belopp efter ökning: {(percentageIncrease - 1) * 100:F2}% är: {newAmount:C}");
                            
                            Console.WriteLine("-------------------");

                        //Lägg till till den totala utgiften
                        totalExpenses += newAmount; // Använder den uppdaterade summan
                    }
                    else if (transaction.Type == TransactionType.Income)

                        //Lägg till till den totala inkomsten
                        totalIncome += transaction.Amount; 
                }
            

            //Beräkna det totala saldot
             decimal totalBalance = totalIncome - totalExpenses;

            //Skriv ut total summa efter ökning
            Console.WriteLine($"Totalt saldo efter slumpmässig kostnadsökning: {totalBalance:C}");
        }
    }
}

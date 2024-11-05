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
            try
            {

            //Ladda befintliga transaktioner genom anrop av metod
            var transactions = budgetManager.GetTransactions();


            //Kontroll om data existerar
            if (transactions == null || !transactions.Any())
            {
                Console.WriteLine("Ingen data att bearbeta.");
                return;
            }


            decimal totalIncome = 0; // För att hålla reda på den totala inkomsten
            decimal totalExpenses = 0; // För att hålla reda på totala utgifter


            //Temporär lista för kopior av transaktioner. Orginalvärden ska vara kvar då detta endast är ett test för budgeten.
            var tempTransactions = new List<Transaction>();


            //Loopar igenom transaktioner från listan
            foreach (var transaction in transactions)
            {

                //För varje transaktion skapas kopia av transaktionen
                var tempTransaction = new Transaction(transaction.Type, transaction.Category, transaction.Description, transaction.Amount, transaction.Date);


                //Kontroll om transaktionen är en utgift
                if (tempTransaction.Type == TransactionType.Expense)
                {

                    //Applicera slumpmässig procentuell ökning upp till 50%
                    decimal percentageIncrease = 1 + (decimal)(random.NextDouble() * 0.50);


                    //Lagrar nytt Amount i variabel. Rundar uppåt, lägger till procenten, använder två decimaler.
                    decimal newAmount = Math.Round(transaction.Amount * percentageIncrease, 2);


                    //Anropar metod för uppdatering av belopp gällande transaktion med variabeln newAmount
                    tempTransaction.UpdateTransaction(newAmount);


                    // Skriv ut den ökade utgiftstransaktionen
                    Console.WriteLine($"[Beskrivning]: {transaction.Description}, Nytt belopp efter ökning: {(percentageIncrease - 1) * 100:F2}% är: {newAmount:C}");

                    Console.WriteLine("-------------------");


                    //Lägg till till den totala utgiften
                    totalExpenses += newAmount; // Använder den uppdaterade summan

                }

                else if (tempTransaction.Type == TransactionType.Income)

                    //Lägg till till den totala inkomsten
                    totalIncome += tempTransaction.Amount;


                //Lägger till kopian till den temporära listan
                tempTransactions.Add(tempTransaction);
            }

            //Beräkna det totala saldot
            decimal totalBalance = totalIncome - totalExpenses;


            //Skriv ut total summa efter ökning
            Console.WriteLine($"Totalt saldo efter slumpmässig kostnadsökning: {totalBalance:C}");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid skapande av slumpmässiga utgifter: {ex.Message}");
            }
        }
    }
}

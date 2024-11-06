using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using Mom5_Projekt.Models;

//Instansierar SaveData
SaveData _saveData = new SaveData();

//Definiera filvägen för JSON-filen
string filePath = "budgetData.json";

//Instansierar BudgetManager med saveData som argument för tillgång till metoder
BudgetManager budgetManager = new BudgetManager(_saveData, filePath);

//Laddar transaktioner från JSON
List<Transaction> _transactions = _saveData.LoadTransaction(filePath) ?? new List<Transaction>();

//Debugg
Console.WriteLine("Laddade transaktioner:");
foreach (var transaction in _transactions)
{
    Console.WriteLine(transaction.DisplayInfo());
}


//Boolean som kontrollerar om programmet ska avslutas
bool programRunning = true;


while (programRunning)
{
    Console.Clear();

    Console.WriteLine("BudgetApp");
    Console.WriteLine("----------");
    Console.WriteLine("1. Lägg till inkomst");
    Console.WriteLine("2. Visa alla transaktioner");
    Console.WriteLine("3. Beräkna saldo");
    Console.WriteLine("4. Radera transaktion");
    Console.WriteLine("---------------");
    Console.WriteLine("5. Testa budget");
    Console.WriteLine("6. Avsluta programmet");
    Console.WriteLine("---------------");

    //Variabel som lagrar input
    string input = Console.ReadLine();


    //Kontroll om input kan konverteras till heltal
    if (int.TryParse(input, out int option))
    {
        try
        {
            switch (option)
            {

                case 1:
                    Console.Clear();


                    Console.WriteLine("Är transaktionen en utgift eller inkomst? : ");
                    string typeInput = Console.ReadLine().Trim();

                    //Kontrollerar inmatning 
                    if (!string.Equals(typeInput, "Inkomst", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(typeInput, "Utgift", StringComparison.OrdinalIgnoreCase))

                    {
                        Console.WriteLine("Ogiltig typ. Ange 'Inkomst' eller 'Utgift'");

                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }

                    //Konverterar input till TransactionType
                    TransactionType type = typeInput.Equals("Inkomst", StringComparison.OrdinalIgnoreCase)
                    ? TransactionType.Income
                    : TransactionType.Expense;

                    Console.WriteLine("Ange kategori för transaktion: ");
                    string category = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(category))
                    {
                        Console.WriteLine("Var god ange kategori.");
                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("Ange beskrivning för transaktion: ");
                    string description = Console.ReadLine().Trim();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine("Var god ange beskrivning.");
                        
                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }


                    Console.WriteLine("Ange belopp för transaktion: ");
                    string amountInput = Console.ReadLine();
                    decimal amount;


                    //Kontroll om korrekt belopp
                    if (!decimal.TryParse(amountInput, out amount) || (amount <= 0))
                    {
                        Console.WriteLine("Ogiltigt belopp. Ange positivt tal.");
                        
                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }



                    Console.Write("Ange datum (yyyy-mm-dd): ");
                    string dateInput = Console.ReadLine();
                    DateTime date;


                    //Kontroll för datumformat
                    if (!DateTime.TryParse(dateInput, out date))
                    {
                        Console.WriteLine("Ogiltigt datumformat. Försök igen.");

                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;
                    }


                    //Anropar add.Transaction från BudgetManager
                    budgetManager.addTransaction(type, category, description, amount, date);

                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break;



                //Visa transaktioner
                case 2:
                   
                   Console.Clear();

                    budgetManager.displayTransactions();

                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break;





                //Beräkna totalt saldo
                case 3:
                    Console.Clear();

                    //Anropar CalculateBalance med transaktionslistan
                    decimal balance = budgetManager.CalculateBalance();

                    //Skriver ut totalt saldo
                    Console.WriteLine($"Det totala saldot är: {balance}");

                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break;





                //Radera transaktion
                case 4:
                    Console.Clear();

                    //Skriver ut transaktioner
                    budgetManager.displayTransactions();

                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine("Ange index för transaktion som önskas raderas: ");

                    //Lagrar input
                    string deleteInput = Console.ReadLine();


                    //Kontroll om användaren anger giltigt index
                    if (!int.TryParse(deleteInput, out int deleteIndex))
                    {
                        Console.WriteLine("Ogitligt index. Försök igen.");
                        
                        Console.WriteLine("Tryck på valfri tangent...");
                        Console.ReadKey();
                        continue;

                    }

                    //Justerar till 0 index för listan
                    budgetManager.deleteTransaction(deleteIndex -1);

                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break;





                case 5:

                    Console.Clear();

                    Console.WriteLine("Din budgets kapacitet kommer nu testas genom slumpmässig, procentuell ökning: ");

                    Console.ReadKey();

                    Console.Clear();

                    budgetManager.TestBudget();

                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine("Tryck på valfri tangent...");

                    Console.ReadKey();

                    continue;




                case 6:
                    programRunning = false;
                    Console.WriteLine("Programmet avslutas.");
                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Något gick fel: {ex.Message}");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Ogiltigt val, försök igen.");
        Console.WriteLine("Tryck på valfri tangent...");
        Console.ReadKey();
    }


}
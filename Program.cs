//Huvudmenyn

using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using Mom5_Projekt.Models;

//Instansierar SaveData
SaveData _saveData = new SaveData();

//Instansierar BudgetManager med saveData som argument för tillgång till metoder
BudgetManager budgetManager = new BudgetManager(_saveData);

//Laddar transaktioner från JSON
List<Transaction> transactions = _saveData.LoadTransaction() ?? new List<Transaction>();

//Boolean som kontrollerar om programmet ska avslutas
 bool programRunning = true;

while (programRunning)
{
    Console.Clear();
            
    Console.WriteLine("BudgetApp");
    Console.WriteLine("----------");
    Console.WriteLine("1. Lägg till inkomst");
    Console.WriteLine("2. Lägg till utgift");
    Console.WriteLine("3. Visa alla transaktioner");
    Console.WriteLine("4. Beräkna saldo");
    Console.WriteLine("5. Radera transaktion");
    Console.WriteLine("---------------");
    Console.WriteLine("6. Testa budget");
    Console.WriteLine("7. Avsluta programmet");
    Console.WriteLine("---------------");

    //Variabel som lagrar input
    string input = Console.ReadLine();

    
    //Kontroll om input kan konverteras till heltal
    if (int.TryParse(input, out int option))
    {
        try{
            switch (option)
            {
                case 1:
                Console.Clear();

                Console.WriteLine("Är transaktionen en utgift eller inkomst? : ");
                string typeInput = Console.ReadLine().Trim();

                //Konverterar input till TransactionType
                TransactionType type;
                if (typeInput.Equals("Inkomst", StringComparison.OrdinalIgnoreCase))
                {
                    type = TransactionType.Income;
                }
                else if (typeInput.Equals("Utgift", StringComparison.OrdinalIgnoreCase))
                {
                    type = TransactionType.Expense;
                }
                else
                {
                    Console.WriteLine("Ogiltig typ. Vargod ange 'Utgift' eller 'Inkomst'.");
                    break;
                }

                Console.WriteLine("Ange kategori för transaktion: ");
                string category = Console.ReadLine();

                Console.WriteLine("Ange beskrivning för transaktion: ");
                string description = Console.ReadLine();

                Console.WriteLine("Ange belopp för transaktion: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                
                //Kontroll om korrekt belopp
                 if (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Ogiltigt belopp. Försök igen.");
                    break;
                }

                Console.Write("Ange datum (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                
                //Kontroll för datumformat
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                    break;
                }

                //Anropar add.Transaction från BudgetManager
                budgetManager.addTransaction(type, category, description, amount, date);

                 Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break; 
          
          

                case 3:
               Console.Clear();



                    budgetManager.displayTransactions();
                  
                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break; 



                //Beräkna totalt saldo
                case 4:
               Console.Clear();

                //Anropar CalculateBalance med transaktionslistan
                decimal balance = budgetManager.CalculateBalance(transactions);
  
                    //Skriver ut totalt saldo
                    Console.WriteLine($"Det totala saldot är: {balance}");

                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break; 



                //Radera transaktion
                case 5:
                Console.Clear();

                //Skriver ut transaktioner
               budgetManager.displayTransactions();

            Console.WriteLine(Environment.NewLine);

               Console.WriteLine("Ange index för transaktion som önskas raderas: ");

                //Lagrar input
                string deleteInput = Console.ReadLine();
                
                    
               //Kontroll om input kan konverteras till heltal
               if (int.TryParse(deleteInput, out int deleteIndex))
               {
                    //Debugging output
                     Console.WriteLine($"Du angav index: {deleteIndex}"); 
                   
                   //Justerar till 0 index för listan
                    budgetManager.deleteTransaction(deleteIndex -1);    
               }
               else
               {
                Console.WriteLine("Ogiltigt index. Försök igen.");              
               }
                
                Console.WriteLine("Tryck på valfri tangent...");
                Console.ReadKey();
                break;





          
              case 7:
               programRunning = false;
                    Console.WriteLine("Programmet avslutas.");
                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
          
          
            } 
          
        } catch (Exception ex)
    {
        Console.WriteLine($"Något gick fel: {ex.Message}");
    }
    }
     else
    {
        Console.WriteLine("Ogiltigt val, försök igen.");
    }


    }
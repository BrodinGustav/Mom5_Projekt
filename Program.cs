//Huvudmenyn

using System.Collections;
using System.Net;
using System.Runtime.InteropServices;
using Mom5_Projekt.Models;

//Instansierar SaveData
SaveData _saveData = new SaveData();

//Instansierar BudgetManager med saveData som argument för tillgång till metoder
BudgetManager budgetManager = new BudgetManager(_saveData);

//Boolean som kontrollerar om programmet ska avslutas
 bool programRunning = true;

while (programRunning)
{
    //Console.Clear();
            //Skriver om skärm efter varje menyval
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

                Console.WriteLine("Ange kategori för transaktion: ");
                string category = Console.ReadLine();

                Console.WriteLine("Ange beskrivning för transaktion: ");
                string description = Console.ReadLine();

                Console.WriteLine("Ange belopp för transaktion: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.Write("Ange datum (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                //Anropar add.Transaction från BudgetManager
                budgetManager.addTransaction(category, description, amount, date);

                 Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break; 
          
          

                case 3:
                Console.Clear();

                    budgetManager.displayTransactions();
                  
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
            

                Console.WriteLine("Tryck på valfri tangent...");
                Console.ReadKey();
                
                    
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
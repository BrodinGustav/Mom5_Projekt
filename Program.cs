//Huvudmenyn

using System.Collections;
using System.Net;
using System.Runtime.InteropServices;
using Mom5_Projekt.Models;

//Instansierar BudgetManager
BudgetManager budgetManager = new BudgetManager();

//Boolean som kontrollerar om programmet ska avslutas
 bool programRunning = true;

while (programRunning)
{
    Console.Clear();
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

                //Instansierar Transaction
                Transaction transaction = new Income(description, amount, date);

                //Anropar RegisterTransaction genom budgetManager
                budgetManager.RegisterTransaction(category, transaction);

                    Console.WriteLine("Transaktionen har registrerats!");
                    Console.WriteLine("Tryck på valfri tangent...");
                    Console.ReadKey();
                    break; 
          
          

                case 3:
                Console.Clear();

                 Console.WriteLine("Ange kategori för att visa transaktioner: ");
                 category = Console.ReadLine(); 

                budgetManager.GetTransactions(category);
                  
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
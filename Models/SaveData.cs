using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Mom5_Projekt.Models
{
    
       public class SaveData
    {
        public void saveBudget(TransactionCategory transactionCategory, string filePath)
        {
              try
        {

            //Serialiserar listan av transaktioner
            string json = JsonSerializer.Serialize(transactionCategory.GetCategoriesCopy(), new JsonSerializerOptions {WriteIndented = true});

            //Debugg
            Console.WriteLine("JSON-data som ska sparas: " + json);

            //Skriv JSON till fil
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data har sparats!");
             }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett I/O-fel uppstod: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Åtkomst nekad: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Något gick fel: {ex.Message}");
        }
    }
    

        public void LoadDataFromFile(string filePath, TransactionCategory transactionCategory)
        {
            if(File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);

                var loadedData = JsonSerializer.Deserialize<Dictionary<string, List<Transaction>>>(jsonData);

                 //Om data är laddad korrekt, uppdatera _categories i TransactionCategory
            if (loadedData != null)
            {
                transactionCategory.GetCategoriesCopy();
                Console.WriteLine("Data har laddats och uppdaterat kategorierna.");
            }
        }
         else
        {
            Console.WriteLine("Filen finns inte.");
        }

            }
        
        }
            
    }



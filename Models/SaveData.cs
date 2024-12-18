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

        //Deklarerar lista som lagrar transaktioner
        public List<Transaction> _transactionList { get; set; }

        //Filväg där transaktioner sparas
        private readonly string filePath; 

        //Konstruktor
        public SaveData()
        {
            //Säkerställer att listan är initialiserad
            _transactionList = new List<Transaction>();

            //Ger värde till readonly variabeln
            filePath = "budgetData.json";
        }

        //Metod för att spara transaktion
        public void SaveTransaction(List<Transaction> _transactionsList)
        {
            try
            {

                //Kontroll om listan är null
                if (_transactionsList == null || !_transactionsList.Any())
                {
                    Console.WriteLine("Transaktionslistan är tom, inget att spara.");
                    return;
                }

                //Serialiserar listan till JSON-sträng.
                string json = JsonSerializer.Serialize(_transactionsList, new JsonSerializerOptions { WriteIndented = true });

                //Skriver över Json-sträng till fil
                File.WriteAllText(filePath, json);

                Console.WriteLine("Transaktionen är uppdaterad!");
            }

            catch (IOException ex) //Hantera eventuella IO-fel, t.ex. om filen inte kan skrivas
            {
                Console.WriteLine($"Ett fel inträffade vid skrivning till filen: {ex.Message}");
            }
            catch (JsonException ex) //Hantera eventuella fel under serialisering
            {
                Console.WriteLine($"Ett fel inträffade vid serialisering av budgetdata: {ex.Message}");
            }
            catch (Exception ex) //Hantera eventuella oväntade fel
            {
                Console.WriteLine($"Ett oväntat fel inträffade: {ex.Message}");
            }
        }



        //Metod för att ladda sparad transaktion
        public List<Transaction> LoadTransaction(string filePath)
        {

            try
            {

                //Kontroll om filen finns
                if (!File.Exists(filePath))
                
                {
                         Console.WriteLine("Ingen fil hittades för att ladda transaktioner.");
                        
                        //Returnerar tom lista om filen inte finns
                        return new List<Transaction>(); 
                }

                    //Läser in filen som sträng
                    string jsonText = File.ReadAllText(filePath);

                    //Deserialiserar JSON-sträng till lista av objekt
                    var transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonText);

                    //Kontroll om deserialisering lyckades
                    return transactions ?? new List<Transaction>();
            
            }

            catch (IOException ex) //Hantera eventuella IO-fel, t.ex. om filen inte kan skrivas
            {
                Console.WriteLine($"Ett fel inträffade vid deserialisering av transaktioner: {ex.Message}");
            }
            catch (JsonException ex) //Hantera eventuella fel under serialisering
            {
                Console.WriteLine($"Ett fel inträffade vid serialisering av budgetdata: {ex.Message}");
            }
            catch (Exception ex) //Hantera eventuella oväntade fel
            {
                Console.WriteLine($"Ett oväntat fel inträffade: {ex.Message}");
            }

            Console.WriteLine("Inga transaktioner hittades.");

            //Returnerar tom lista
            return new List<Transaction>();
        }

    }

}
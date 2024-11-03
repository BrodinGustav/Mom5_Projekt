using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mom5_Projekt.Models
{
    public class BudgetManager
    {
        //Instansierar SaveData
        SaveData _saveData = new SaveData();
       


        //Deklarerar lista utifrån basklassen TransactionBluePrint som lagrar transaktioner
            public List<TransactionBluePrint> _transactionBluePrintList { get; set; }


    public BudgetManager()
    {
        //Listobjekt utifrån klassen med struktur från basklassen
        _transactionBluePrintList = new List<TransactionBluePrint>();
     
    }

       //Anropar metod från klassen SaveData för att läsa in sparade transaktioner
        public void LoadTransaction()
        {
            _saveData.LoadTransaction();
        }
    

            //Metod för att registrera transaktion
            public void addTransaction()
            {

            }

            //Metod för att skriva ut transaktioner

            //Metod för att radera transaktion

    }

}
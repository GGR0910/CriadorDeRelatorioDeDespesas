using ExpensesReport.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Interactions
{
    internal static class MainMenu
    {
        public static void StartMenssage()
        {
            Console.WriteLine("Bem vindo ao gerador de relatórios!");
            Console.WriteLine("Essas são as opções disponíveis:");
            MenuOptions.ShowMenuOptions();
        }
        
    }
}

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

        public static void CheckForContinue()
        {
            Console.WriteLine("Deseja realizar outra análise? Sim ou nao.");
            string answer = Console.ReadLine().ToLower();

            if(answer == "sim")
            {
                Console.Clear();
                MenuOptions.ShowMenuOptions();
            }
            else if(answer == "nao")
            {
                Console.WriteLine("Obrigado por utilizar o gerador de relatórios!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Opção inválida, por favor digite sim ou nao.");
                CheckForContinue();
            }
        }


    }
}

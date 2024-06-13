using ExpensesReport.Models.Enuns;
using ExpensesReport.Processes;
using ExpensesReport.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Interactions
{
    internal static class MenuOptions
    {
        public static void ShowMenuOptions()
        {

            var menuOptions = MenuOptionsService.GetAll();
            foreach (var menuOption in menuOptions)
            {
                Console.WriteLine($"{menuOption.Text} - {menuOption.Description}");
            }
            GetOption();
           
        }

        private static void GetOption()
        {
            Console.WriteLine("Digite o número da opção desejada:");
            var optionStr = Console.ReadLine();
            Console.WriteLine($"Opção escolhida: {optionStr}");

            if (!ValidateResponse(optionStr))
                GetOption();
            else
            {
                var option = int.Parse(optionStr);
                var archivePath = GetArchivePath();
                Console.Clear();

                CallReportProcess(option, archivePath);
            }
        }

        private static string GetArchivePath()
        {
            Console.WriteLine("Qual o diretório do relatório?");
            return Console.ReadLine();
        }

        private static bool ValidateResponse(string optionStr)
        {
            bool result = int.TryParse(optionStr, out int value);
            if (!result || !Enum.IsDefined(typeof(ReportTypeEnum), value))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                return false;
            }

            return true;
        }

        private static void CallReportProcess(int reportType, string archivePath)
        {
            try
            {
                switch (reportType)
                {
                    case (int)ReportTypeEnum.ExpensesReportByCategories:
                        Console.WriteLine("Chamando relatório por categorias...");
                        ExpensesReportByCategories.StartProcess(archivePath);
                        break;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erro ao chamar o processo de relatório: {ex.Message}");
                string newArchivePath = GetArchivePath();
                Console.Clear();
                CallReportProcess(reportType, newArchivePath);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro ao chamar o processo de relatório: {ex.Message}");
                string newArchivePath = GetArchivePath();
                Console.Clear();
                CallReportProcess(reportType, newArchivePath);
            }
           

        }
    }
}

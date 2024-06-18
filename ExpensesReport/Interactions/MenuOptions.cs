using ExpensesReport.Models.Enuns;
using ExpensesReport.Processes;
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

            Console.WriteLine("1-Gastos por mês.");
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
                    case (int)ReportTypeEnum.MonthExpensesReport:
                        Console.WriteLine("Lembre de mandar um relatório com Data, Categoria, Valor, FormaPagamento, Reembolso e Item como colunas.");
                        Console.WriteLine("Chamando relatório de gastos do mês...");
                        MonthExpensesReport.RunProcess(archivePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao chamar o processo de relatório: {ex.Message}");
                string newArchivePath = GetArchivePath();
                Console.Clear();
                CallReportProcess(reportType, newArchivePath);
            }

        }
    }
}

using ExpensesReport.Interactions;
using ExpensesReport.Models.DTOs;
using ExpensesReport.Utils;
using ExpensesReport.Utils.DataSourceValidators;
using ExpensesReport.Utils.EmailWorker;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpensesReport.Processes
{
    internal static class MonthExpensesReport
    {
        public static readonly string[] AcceptedColumns = { "Data", "Categoria", "Valor", "FormaPagamento", "Reembolso", "Item" };
        public static void RunProcess(string archivePath)
        {
            try { 
                GeneralArchiveValidators.ValidateArchive(archivePath);
                MemoryStream archive = LocalDataAccess.GetArchive(archivePath);
                ExcelWorksheet worksheet = LocalDataAccess.GetWorkSheet(archive);
                MonthExpensesValidator.ValidateArchiveData(worksheet);

                List<Expense> data = LocalDataAccess.DesserializeDataToExpenses(worksheet);

                string emailToSendTo = GeneralTexts.GetEmailToSendTo();

                Console.WriteLine("Criando documento...");

                EmailClient client = new EmailClient(emailToSendTo, "Relatório de despesas", CreateBody(data));

                Console.WriteLine("Enviando documento...");
                
                client.SendEmail();

                MainMenu.CheckForContinue();
            }
            catch
            {
                throw;
            }
        }

        private static string CreateBody(List<Expense> data)
        {
            string competencyMonth = GeneralTexts.GetCompetencyMonth();

            StringBuilder htmlString = new StringBuilder();

            htmlString.Append("<style> tr{ text-align: center; } </style>");

            htmlString.Append($"<span>Segue o relatório de gastos do mês {competencyMonth}</span>");
            htmlString.Append("<br>");
            htmlString.Append("<p>1-Gastos por categoria:</p>");

            GenerateExpensesByCategorieTable(data, ref htmlString);
            htmlString.Append("--------------------------------------");

            htmlString.Append("<p>2-Gastos por dia:</p>");
            GenerateExpensesByDayTable(data, ref htmlString);
            htmlString.Append("--------------------------------------");

            htmlString.Append("<p>3- Dez maiores gastos:</p>");
            GenerateBiggerExpensesTable(data, ref htmlString);
            htmlString.Append("--------------------------------------");
            AddRefundAndTotals(data, ref htmlString);

            return htmlString.ToString();
        }

        private static void AddRefundAndTotals(List<Expense> data, ref StringBuilder htmlString)
        {
            try
            {
                var totalSpentWithoutRefund = data.Sum(x => x.Value);
                var totalSpentWithRefund = data.Sum(x => x.Value - x.Refund);
                var totalRefund = data.Sum(x => x.Refund);

                htmlString.Append($"<p>Total gasto sem rembolso: {totalSpentWithoutRefund}</p>");
                htmlString.Append($"<p>Total gasto com rembolso: {totalSpentWithRefund}</p>");
                htmlString.Append($"<p>Total de reembolso recebido: {totalRefund}</p>");
            }
            catch
            {
                throw;
            }
            
        }

        private static void GenerateExpensesByCategorieTable(List<Expense> data, ref StringBuilder htmlString)
        {
            try{

                htmlString.Append("<table>");
                htmlString.Append("<thead>");
                htmlString.Append("<tr>");
                htmlString.Append("<th>Categoria</th>");
                htmlString.Append("<th>Total Gasto</th>");
                htmlString.Append("</tr>");
                htmlString.Append("</thead>");
                htmlString.Append("<tbody>");


                var expensesByCategorie = data.GroupBy(x => x.Category).Select(x => new { Categorie = x.Key, Total = x.Sum(y => y.Value - y.Refund) });

                foreach (var item in expensesByCategorie)
                {
                    htmlString.Append("<tr>");
                    htmlString.Append($"<td>{item.Categorie}</td>");
                    htmlString.Append($"<td>{item.Total}</td>");
                    htmlString.Append("</tr>");
                }

                htmlString.Append("</tbody>");
                htmlString.Append("</table>");
            }
            catch
            {
                throw;
            }
        }

        private static void GenerateExpensesByDayTable(List<Expense> data, ref StringBuilder htmlString)
        {
            try
            {
                htmlString.Append("<table>");
                htmlString.Append("<thead>");
                htmlString.Append("<tr>");
                htmlString.Append("<th>Data</th>");
                htmlString.Append("<th>Total Gasto</th>");
                htmlString.Append("</tr>");
                htmlString.Append("</thead>");
                htmlString.Append("<tbody>");


                var expensesByDay = data.GroupBy(x => x.DayOfMonth).Select(x => new { Categorie = x.Key, Total = x.Sum(y => y.Value - y.Refund) });

                foreach (var item in expensesByDay)
                {
                    htmlString.Append("<tr>");
                    htmlString.Append($"<td>{item.Categorie}</td>");
                    htmlString.Append($"<td>{item.Total}</td>");
                    htmlString.Append("</tr>");
                }

                htmlString.Append("</tbody>");
                htmlString.Append("</table>");
            }
            catch
            {
                throw;
            }
           
        }

        private static void GenerateBiggerExpensesTable(List<Expense> data, ref StringBuilder htmlString)
        {
            try
            {
                htmlString.Append("<table>");
                htmlString.Append("<thead>");
                htmlString.Append("<tr>");
                htmlString.Append("<th>Data</th>");
                htmlString.Append("<th>Categoria</th>");
                htmlString.Append("<th>Item</th>");
                htmlString.Append("<th>Total Gasto</th>");
                htmlString.Append("</tr>");
                htmlString.Append("</thead>");
                htmlString.Append("<tbody>");


                var biggerExpenses = data.OrderByDescending(x => x.DayOfMonth).Take(10).ToList();

                foreach (var item in biggerExpenses)
                {
                    htmlString.Append("<tr>");
                    htmlString.Append($"<td>{item.DayOfMonth}</td>");
                    htmlString.Append($"<td>{item.Category}</td>");
                    htmlString.Append($"<td>{item.Item}</td>");
                    htmlString.Append($"<td>{item.Value - item.Refund}</td>");
                    htmlString.Append("</tr>");
                }

                htmlString.Append("</tbody>");
                htmlString.Append("</table>");
            }
            catch
            {
                throw;
            }
            
        }
    }
}

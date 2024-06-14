using ExpensesReport.Models.DTOs;
using ExpensesReport.Utils;
using ExpensesReport.Utils.DataSourceValidators;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            }
            catch
            {
                throw;
            }
        }

        

    }
}

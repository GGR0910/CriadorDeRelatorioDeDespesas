using ExpensesReport.Models.DTOs;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils
{
    internal static class LocalDataAccess
    {
        public static MemoryStream GetArchive(string archivePaht)
        {
            Console.WriteLine("Pegando arquivo...");
            using (var fileStream = new FileStream(archivePaht, FileMode.Open, FileAccess.Read))
            {
                var memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);
                return memoryStream;
            }
        }

        public static ExcelWorksheet GetWorkSheet(MemoryStream stream)
        {
            ExcelPackage excelPackage = new ExcelPackage(stream);
            return excelPackage.Workbook.Worksheets.First();
        }

        public static List<Expense> DesserializeDataToExpenses(ExcelWorksheet worksheet)
        {
            List<Expense> expenses = new List<Expense>();
            for (int i = 2; i <= worksheet.Rows.Count(); i++)
            {
                expenses.Add(new Expense
                {
                    DayOfMonth = int.Parse(worksheet.Cells[i, 1].Value.ToString()),
                    Category = worksheet.Cells[i, 2].Value.ToString(),
                    Value = decimal.Parse(worksheet.Cells[i, 3].Value.ToString()),
                    PaymentMethod = worksheet.Cells[i, 4].Value.ToString(),
                    Refund = int.Parse(worksheet.Cells[i, 5].Value.ToString()),
                    Item = worksheet.Cells[i, 6].Value.ToString()
                });
            }
            return expenses;
        }
    }
}

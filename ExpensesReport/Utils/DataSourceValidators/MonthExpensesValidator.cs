
using ExpensesReport.Processes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils.DataSourceValidators
{
    internal class MonthExpensesValidator 
    {
        public static void ValidateArchiveData(ExcelWorksheet worksheet)
        {
            try
            {
                Console.WriteLine("Validando dados para o relatório por categorias...");
                
                for(int i = 1; i <= 6; i++)
                {
                    if(!Processes.MonthExpensesReport.AcceptedColumns.Contains(worksheet.Cells[1, i].Value))
                        throw new FormatException("Colunas inválidas no arquivo de despesas.");
                }

                for(int i = 2; i <= worksheet.Rows.Count(); i++)
                {
                    if (!int.TryParse(worksheet.Cells[i, 1].Value.ToString(), out int dataValue))
                        throw new FormatException("Coluna 'Data' deve conter apenas o dia do mês.");

                    if (!decimal.TryParse(worksheet.Cells[i, 3].Value.ToString(), out decimal valorValue))
                        throw new FormatException("Coluna 'Valor' deve conter apenas valores numéricos.");

                    if (!int.TryParse(worksheet.Cells[i, 5].Value.ToString(), out int reembolsoValue))
                        throw new FormatException("Coluna 'Reembolso' deve conter apenas valores numéricos.");
                }
            }
            catch
            {
                throw;
            }
            
        }
    }
}

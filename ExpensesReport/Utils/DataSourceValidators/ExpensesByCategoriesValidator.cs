
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils.DataSourceValidators
{
    internal class ExpensesByCategoriesValidator 
    {
        public static bool ValidateArchiveData(MemoryStream archive)
        {
            try
            {
                Console.WriteLine("Validando dados para o relatório por categorias...");
                


                return true;
            }
            catch
            {
                throw;
            }
            
        }
    }
}

using ExpensesReport.Utils;
using ExpensesReport.Utils.DataSourceValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Processes
{
    internal static class ExpensesReportByCategories
    {
        public static void StartProcess(string archivePath)
        {
            try { 
                GeneralArchiveValidators.ValidateArchive(archivePath);
                MemoryStream archive = LocalDataAccess.GetArchive(archivePath);
                ExpensesByCategoriesValidator.ValidateArchiveData(archive);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

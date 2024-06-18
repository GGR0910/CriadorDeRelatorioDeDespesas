using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils
{
    internal static class CalendarTranslations
    {
        public static string GetMonthName()
        {
            return DateTime.Now.ToString("MMMM", new CultureInfo("pt-br"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils
{
    internal static class GeneralTexts
    {

        public static string GetEmailToSendTo()
        {
            Console.WriteLine("Para que e-mail devemos enviar o relatório?");
            return Console.ReadLine();
        }

        public static string GetCompetencyMonth()
        {
            Console.WriteLine("De que mês são esses gastos?");
            return Console.ReadLine();
        }

    }
}

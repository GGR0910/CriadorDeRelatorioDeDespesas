using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Utils
{
    internal static class GeneralArchiveValidators
    {
        public static void ValidateArchive(string archivePath)
        {
            Console.WriteLine("Validando formato e tipo...");
            if (!File.Exists(archivePath))
                throw new FileNotFoundException("Arquivo não encontrado", archivePath);

            string extension = Path.GetExtension(archivePath);
            if(!extension.Equals(".xls") && !extension.Equals(".xlsx"))
                throw new FormatException("Formato de arquivo inválido. Apenas arquivos .csv, .xls e .xlsx são aceitos.");

        }
    }
}

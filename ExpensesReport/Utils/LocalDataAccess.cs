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
    }
}

using ExpensesReport.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Models
{
    internal class Report : BaseEntity
    {
        public ReportTypeEnum ReportType { get; set; }
        public DateTime CompentencyDate { get; set; }
        public string DestinationEmail { get; set; }
        public string ArchiveOrignPath { get; set; }
        public string ReportData { get; set; }
    }
}

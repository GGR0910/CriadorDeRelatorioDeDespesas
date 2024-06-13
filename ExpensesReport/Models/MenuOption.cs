using ExpensesReport.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Models
{
    internal class MenuOption : BaseEntity
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public ReportTypeEnum ReportType { get; set; }
    }
}

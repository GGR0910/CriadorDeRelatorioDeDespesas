using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Models.DTOs
{
    internal class Expense
    {
        public int DayOfMonth { get; set; }
        public string Category { get; set; }
        public decimal Value { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Refund { get; set; }
        public string Item { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesReport.Models
{
    internal class SpendOperation : BaseEntity
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        public SpendOperation(string category, string description, decimal value, DateTime date)
        {
            Category = category;
            Description = description;
            Value = value;
            Date = date;
        }
    }
}

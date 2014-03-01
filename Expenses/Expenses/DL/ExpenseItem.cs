using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Expenses.DL
{
    public class ExpenseItem
    {
        public int Id { get; set; }

        [Required]
        public Expense Expense { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

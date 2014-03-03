using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public class ExpenseItem
    {
        public int Id { get; set; }

        [Required]
        public virtual Expense Expense { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public virtual User Creator { get; set; }
    }
}

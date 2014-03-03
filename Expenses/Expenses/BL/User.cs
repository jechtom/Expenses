using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<ExpenseItem> ExpenseItems { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}

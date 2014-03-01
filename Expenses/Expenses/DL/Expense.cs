using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.DL
{
    public class Expense
    {
        public int Id { get; set; }

        public virtual ICollection<ExpenseItem> Items { get; set; }

        public string Name { get; set; }

        public 
    }
}

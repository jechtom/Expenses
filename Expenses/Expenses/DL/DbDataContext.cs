using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.DL
{
    public class DbDataContext : DbContext
    {
        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<ExpenseItem> ExpenseItem { get; set; }
    }
}

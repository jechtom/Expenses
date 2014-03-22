using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts
{
    public class ExpensesCostDetailDto
    {
        public decimal Cost { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
    }
}

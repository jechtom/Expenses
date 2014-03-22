using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts
{
    public class ExpensesUserReportDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public decimal TotalCost { get; set; }
        public ExpensesCostDetailDto[] CostDetails { get; set; }
    }
}

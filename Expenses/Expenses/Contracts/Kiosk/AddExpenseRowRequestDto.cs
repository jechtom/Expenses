using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts.Kiosk
{
    public class AddExpenseRowRequestDto
    {
        public int ExpenseId { get; set; }
        public decimal Quantity { get; set; }
        public string UserFullName { get; set; }
        public int? UserId { get; set; }
    }
}

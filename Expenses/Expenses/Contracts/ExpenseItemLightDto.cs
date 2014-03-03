using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Contracts
{
    public class ExpenseItemLightDto
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string CreatorFullName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

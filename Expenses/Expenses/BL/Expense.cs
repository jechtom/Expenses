using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public class Expense
    {
        public int Id { get; set; }

        public virtual ICollection<ExpenseItem> Items { get; set; }

        public string Name { get; set; }

        public AmountType AmountType { get; set; }

        [Required]
        public virtual ExpenseIcon Icon { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        public bool IsKioskModeAllowed { get; set; }

        public decimal GetTotalQuantity()
        {
            return Items.Sum(i => i.Amount);
        }
    }
}

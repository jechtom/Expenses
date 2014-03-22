using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public class ExpensePricing
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets cost added per each user.
        /// </summary>
        public decimal? CostPerSingleUser { get; set; }

        /// <summary>
        /// Gets or sets cost of this expense. If set, it is divided by total amount and multiplied by sum of amount for current user.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Get or sets cost per amount = 1. It is multiplied by number of users.
        /// </summary>
        public decimal? CostPerOneQuantity { get; set; }
    }
}

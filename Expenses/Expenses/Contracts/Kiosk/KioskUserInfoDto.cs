using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts.Kiosk
{
    public class KioskUserInfoDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public bool IsInRequestQueue { get; set; }
        public decimal? WaitingQueueQuantity { get; set; }
        public decimal TotalQuantity { get; set;}
        public DateTime? LastExpenseRowCreated { get; set; }
    }
}

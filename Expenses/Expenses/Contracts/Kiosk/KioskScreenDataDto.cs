using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts.Kiosk
{
    public class KioskScreenDataDto
    {
        public string ExpenseName { get; set; }
        public string CreatorFullName { get; set; }
        public decimal TotalQuantity { get; set; }
        public int IconId { get; set; }
        public KioskUserInfoDto[] Users { get; set; }
    }
}

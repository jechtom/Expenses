using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Contracts.Kiosk
{
    public class KioskExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IconId { get; set; }
    }
}

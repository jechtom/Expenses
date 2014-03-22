using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Contracts
{
    public class ExpensesReportDto
    {
        public ExpensesUserReportDto[] Users { get; set; }
    }
}

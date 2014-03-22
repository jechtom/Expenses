using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Contracts.Kiosk
{
    public interface IKioskService
    {
        KioskScreenDataDto GetScreenDataForExpense(int expenseId);
        void AddExpenseRow(AddExpenseRowRequestDto data);

        KioskExpenseDto[] GetExpensesWithKioskEnabled();
    }
}

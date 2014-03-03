using Expenses.DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class ExpenseService : DataContextService
    {
        public Contracts.ExpenseLightDto[] FetchAll()
        {
            return DataContext.ExpensesAsLightDto.ToArray();
        }

        public Expense FetchById(int id)
        {
            return DataContext.Expenses.SingleOrDefault(i => i.Id == id);
        }

        public Expense CreateNew()
        {
            var result = DataContext.Expenses.Create();
            DataContext.Expenses.Add(result);
            return result;
        }
    }
}

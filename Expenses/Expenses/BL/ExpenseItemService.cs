using Expenses.DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class ExpenseItemService : DataContextService
    {
        public Contracts.ExpenseItemLightDto[] FetchForExpense(Expense expense)
        {
            return DataContext
                .ExpenseItemsAsLightDto.Where(e => e.ExpenseId == expense.Id)
                .ToArray();
        }

        public ExpenseItem FetchById(int id)
        {
            // include "Expense" because when updating entity this value needs to be loaded, more info:
            // http://stackoverflow.com/questions/6038541/ef-validation-failing-on-update-when-using-lazy-loaded-required-properties
            var result = DataContext.ExpenseItem.Include(m => m.Expense).SingleOrDefault(i => i.Id == id);
            return result;
        }

        public ExpenseItem CreateNew(Expense expense)
        {
            var result = DataContext.ExpenseItem.Create();
            result.Expense = expense;
            result.CreatedDate = DateTime.Now;
            expense.Items.Add(result);
            return result;
        }
    }
}

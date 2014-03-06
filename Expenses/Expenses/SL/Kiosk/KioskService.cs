using Castle.Core;
using Expenses.Contracts.Kiosk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.SL.Kiosk
{
    [CastleComponent]
    public class KioskService : IKioskService
    {
        public BL.ExpenseService Expenses { get; set; }
        public BL.ExpenseItemService ExpenseItems { get; set; }
        public BL.UserService Users { get; set; }
        public BL.UnitOfWorkContext Context { get; set; }

        public DL.DbDataContext DataContext { get; set; }
        
        public KioskScreenDataDto GetScreenDataForExpense(int expenseId)
        {
            var expense = Expenses.FetchById(expenseId);
            if(expense == null)
                return null;

            EnsureSupportsKiosAccess(expense);

            // resolve basic info
            var result = new KioskScreenDataDto()
            {
                CreatorFullName = expense.Creator.FullName,
                IconId = expense.Icon.Id,
                ExpenseName = expense.Name,
                TotalQuantity = expense.GetTotalQuantity()
            };

            // resolve users
            result.Users = DataContext.Users.Select(u => new KioskUserInfoDto()
            {
                FullName = u.FullName,
                UserId = u.Id,
                IsInRequestQueue = false,
                WaitingQueueQuantity = null,
                TotalQuantity = u.ExpenseItems.Where(e => e.Id == expense.Id).Sum(e => (decimal?)e.Amount) ?? 0,
                LastExpenseRowCreated = u.ExpenseItems.Where(e => e.Id == expense.Id).Max(e => (DateTime?)e.CreatedDate)
            }).ToArray();

            return result;
        }

        public void AddExpenseRow(AddExpenseRowRequestDto data)
        {
            var expense = Expenses.FetchById(data.ExpenseId);
            if (expense == null)
                throw new Exception("Expense not found.");

            EnsureSupportsKiosAccess(expense);

            var item = ExpenseItems.CreateNew(expense);

            // fetch / create user
            if(data.UserId.HasValue)
            {
                var user = Users.FetchById(data.UserId.Value);
                if (user == null)
                    throw new Exception("User not found.");
                item.Creator = user;
            }
            else
            {
                var user = Users.CreateNew();
                user.FullName = data.UserFullName;
                item.Creator = user;
            }

            // set data
            item.Amount = data.Quantity;

            Context.SaveChanges();
        }

        private void EnsureSupportsKiosAccess(BL.Expense expense)
        {
            // no restrictions yet
        }
    }
}

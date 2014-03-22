using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.DL
{
    public class DbDataContext : DbContext
    {
        public DbDataContext()
        {
            Debug.WriteLine("DbDataContext created " + DateTime.Now.ToString());
        }

        public IDbSet<Expense> Expenses { get; set; }

        public IQueryable<Contracts.ExpenseLightDto> ExpensesAsLightDto
        {
            get
            {
                return Expenses.Select(e => new Contracts.ExpenseLightDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreatorFullName = e.Creator.FullName,
                    IconId = e.Icon.Id,
                    IsKioskModeAllowed = e.IsKioskModeAllowed
                });
            }
        }

        public IDbSet<ExpenseItem> ExpenseItem { get; set; }

        public IQueryable<Contracts.ExpenseItemLightDto> ExpenseItemsAsLightDto
        {
            get
            {
                return ExpenseItem.Select(e => new Contracts.ExpenseItemLightDto()
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    CreatorFullName = e.Creator.FullName,
                    ExpenseId = e.Expense.Id,
                    CreatedDate = e.CreatedDate,
                    CreatorId = e.Creator.Id
                });
            }
        }

        public IDbSet<ExpenseIcon> ExpenseIcons { get; set; }

        public IQueryable<Contracts.ExpenseIconLightDto> ExpenseIconsAsLightDto
        {
            get
            {
                return ExpenseIcons.Select(e => new Contracts.ExpenseIconLightDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ContentType = e.ContentType
                });
            }
        }

        public IDbSet<User> Users { get; set; }

        public IQueryable<Contracts.UserLightDto> UsersAsLightDto
        {
            get
            {
                return Users.Select(e => new Contracts.UserLightDto()
                {
                    Id = e.Id,
                    FullName = e.FullName
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("DbDataContext disposing " + DateTime.Now.ToString());
            base.Dispose(disposing);
        }
    }
}

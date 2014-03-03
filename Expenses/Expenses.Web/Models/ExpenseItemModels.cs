using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expenses.Web.Models
{
    public class ExpenseItemCreateAndEditModel
    {
        public ExpenseItemCreateAndEditModel(bool createNew, BL.Expense expense, Contracts.UserLightDto[] users)
        {
            CreateNew = createNew;
            Expense = expense;
            Users = users;
        }

        public ExpenseItemModel ExpenseItem { get; set; }

        public BL.Expense Expense { get; set; }
        public Contracts.UserLightDto[] Users { get; set; }

        public bool CreateNew { get;set;}
    }

    public class ExpenseItemModel
    {
        public ExpenseItemModel() { }
        public ExpenseItemModel(BL.ExpenseItem item)
        {
            this.Amount = item.Amount;
            this.CreatorUserId = (item.Creator != null) ? item.Creator.Id : new int?();
        }

        [Range(0.01, Double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public int? CreatorUserId { get; set; }

        public void ApplyToBO(BL.ExpenseItem expenseItem, BL.UserService userService)
        {
            expenseItem.Creator = userService.FetchById(CreatorUserId.Value);
            expenseItem.Amount = Amount;
        }
    }
}
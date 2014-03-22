using Expenses.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expenses.Web.Models
{
    public class ExpensesIndexModel
    {
        public Contracts.ExpenseLightDto[] Expenses { get; set; }
    }

    public class ExpensesDetailsModel
    {
        public BL.Expense Expense { get; set; }
    }

    public class ExpensesCreateAndEditModel
    {
        public ExpensesCreateAndEditModel(bool createNew, Contracts.ExpenseIconLightDto[] icons, Contracts.UserLightDto[] users)
        {
            CreateNew = createNew;
            Icons = icons;
            Users = users;
        }
        public bool CreateNew { get; set; }
        public ExpenseModel Expense { get; set; }

        public Contracts.ExpenseIconLightDto[] Icons { get; set; }

        public Contracts.UserLightDto[] Users { get; set; }
    }

    public class ExpenseModel
    {
        public ExpenseModel() { }
        public ExpenseModel(BL.Expense expense)
        {
            this.Name = expense.Name;
            this.AmountType = expense.AmountType;
            this.CreatorUserId = expense.Creator != null ? expense.Creator.Id : new int?();
            this.IconId = expense.Icon != null ? expense.Icon.Id : new int?();
            this.IsKioskModeAllowed = expense.IsKioskModeAllowed;
        }

        public void ApplyToBO(Expense expense, UserService Users, ExpenseIconService Icons)
        {
            expense.Name = this.Name;
            expense.AmountType = this.AmountType;
            expense.Creator = Users.FetchById(this.CreatorUserId.Value);
            expense.Icon = Icons.FetchById(this.IconId.Value);
            expense.IsKioskModeAllowed = this.IsKioskModeAllowed;
        }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public AmountType AmountType { get; set; }

        [Required]
        public int? CreatorUserId { get; set; }

        [Required]
        public int? IconId { get; set; }

        [Required]
        public bool IsKioskModeAllowed { get; set; }
    }
}
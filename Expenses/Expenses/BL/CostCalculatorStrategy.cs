using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class CostCalculatorStrategy
    {
        public IEnumerable<CostCalculatorItem> CalculateCosts(Expense expense, IEnumerable<Contracts.ExpenseItemLightDto> expenseItems)
        {
            var pricing = expense.Pricing;
            if (pricing == null)
                yield break;

            var countOfExpenses = expenseItems.Count();
            var amountTotalSum = expenseItems.Sum(e => e.Amount);
            var expensesPerUser = expenseItems.GroupBy(ae => ae.CreatorId);
            
            foreach (var u in expensesPerUser)
            {
                var amountPerUser = u.Sum(ui => ui.Amount);
                decimal userCost = 0;

                // per user
                userCost += pricing.CostPerSingleUser ?? 0;

                // per one quantity amount
                if (pricing.CostPerOneQuantity.HasValue)
                    userCost += amountPerUser * pricing.CostPerOneQuantity.Value;

                // by total cost (based on total cost and total quantity amount)
                if (pricing.Cost.HasValue)
                    userCost += pricing.Cost.Value * amountPerUser / amountTotalSum;

                if (userCost == 0)
                    continue;

                yield return new CostCalculatorItem()
                {
                    Cost = userCost,
                    UserId = u.Key
                };
            }
        }
    }
}

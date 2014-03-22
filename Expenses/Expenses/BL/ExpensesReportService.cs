using Expenses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class ExpensesReportService : DataContextService
    {
        public Contracts.ExpensesReportDto GenerateReport()
        {
            // from user Id to user Id
            var expenseMap = new Dictionary<Tuple<int, int>, decimal>();
            Action<int, int, decimal> addToMap = (fromUser, toUser, amount) =>
            {
                var key = new Tuple<int, int>(fromUser, toUser);
                if (expenseMap.ContainsKey(key))
                    amount += expenseMap[key];

                if (amount != 0)
                    expenseMap[key] = amount;
                else
                    expenseMap.Remove(key);
            };

            // add expenses
            var allExpenses = DataContext.ExpenseItemsAsLightDto.ToArray();
            var calculator = new CostCalculatorStrategy();
            foreach (var expense in DataContext.Expenses.Where(e => e.Pricing != null).ToArray())
            {
                var expenseItems = allExpenses.Where(ei => ei.ExpenseId == expense.Id);
                foreach (var costData in calculator.CalculateCosts(expense, expenseItems))
                {
                    addToMap(costData.UserId, expense.Creator.Id, costData.Cost);
                }
            }

            // remove bi-directional items
            NormalizeMap(expenseMap);

            // build result
            var resultItems = new List<ExpensesUserReportDto>();
            var allUsers = DataContext.UsersAsLightDto.ToDictionary(u=>u.Id);
            foreach (var emi in expenseMap.GroupBy(em => em.Key.Item1))
            {
                var user = allUsers[emi.Key];
                resultItems.Add(new ExpensesUserReportDto()
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    TotalCost = emi.Sum(ei => ei.Value),
                    CostDetails = emi.Select(ei =>
                    new ExpensesCostDetailDto() {
                        Cost = ei.Value,
                        UserId = ei.Key.Item2,
                        FullName = allUsers[ei.Key.Item2].FullName
                    }).ToArray()
                });
            }

            var result = new ExpensesReportDto();
            result.Users = resultItems.ToArray();
            return result;
        }

        private void NormalizeMap(Dictionary<Tuple<int, int>, decimal> expenseMap)
        {
            foreach (var item in expenseMap.ToArray())
            {
                // already processed?
                if(!expenseMap.ContainsKey(item.Key))
                    continue;

                // find reverted value
                var currentKey = item.Key;
                var revertedKey = new Tuple<int, int>(item.Key.Item2, item.Key.Item1);
                if(!expenseMap.ContainsKey(revertedKey))
                    continue;

                // get values from A->B and A<-B
                var currentValue = item.Value;
                var revertedValue = expenseMap[revertedKey];

                if(currentValue == revertedValue)
                {
                    // A owns same amount to B as B owns to A - remove both
                    expenseMap.Remove(currentKey);
                    expenseMap.Remove(revertedKey);
                }
                else if(currentValue > revertedValue)
                {
                    expenseMap[currentKey] = currentValue - revertedValue;
                    expenseMap.Remove(revertedKey);
                }
                else
                {
                    expenseMap[revertedKey] = revertedValue - currentValue;
                    expenseMap.Remove(currentKey);
                }
            }
        }
    }
}

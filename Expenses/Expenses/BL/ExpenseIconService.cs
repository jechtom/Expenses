using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class ExpenseIconService : DataContextService
    {
        public ExpenseIcon CreateNewFromFile(string name, string contentType, byte[] data)
        {
            var result = DataContext.ExpenseIcons.Create();
            result.ContentType = contentType;
            result.Name = name;
            result.Data = data;
            DataContext.ExpenseIcons.Add(result);
            return result;
        }

        public ExpenseIcon FetchById(int id)
        {
            return DataContext.ExpenseIcons.SingleOrDefault(i => i.Id == id);
        }

        public Contracts.ExpenseIconLightDto[] FetchAll()
        {
            return DataContext.ExpenseIconsAsLightDto.ToArray();
        }
    }
}

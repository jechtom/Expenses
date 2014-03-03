using Expenses.DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class UserService : DataContextService
    {
        public Contracts.UserLightDto[] FetchAll()
        {
            return DataContext.UsersAsLightDto.ToArray();
        }

        public User FetchById(int id)
        {
            return DataContext.Users.SingleOrDefault(i => i.Id == id);
        }

        public User CreateNew()
        {
            var result = DataContext.Users.Create();
            DataContext.Users.Add(result);
            return result;
        }
    }
}

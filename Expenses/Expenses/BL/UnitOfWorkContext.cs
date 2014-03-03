using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BL
{
    public class UnitOfWorkContext
    {
        [Dependency]
        public DL.DbDataContext DataContext { get; set; }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}

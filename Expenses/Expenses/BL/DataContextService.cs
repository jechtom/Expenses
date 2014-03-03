using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public abstract class DataContextService
    {
        [Dependency]
        public DL.DbDataContext DataContext { get; set; }
    }
}

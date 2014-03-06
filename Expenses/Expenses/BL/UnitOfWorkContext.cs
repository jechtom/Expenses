using Castle.MicroKernel.Lifestyle.Scoped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Castle.Core;


namespace Expenses.BL
{
    [CastleComponent]
    public class UnitOfWorkContext
    {
        public DL.DbDataContext DataContext { get; set; }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}

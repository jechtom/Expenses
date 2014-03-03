using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Contracts
{
    public class ExpenseLightDto
    {
        public int Id { get; set; }
        
        public string CreatorFullName { get; set; }

        public string Name { get; set; }

        public int IconId { get; set; }
    }
}

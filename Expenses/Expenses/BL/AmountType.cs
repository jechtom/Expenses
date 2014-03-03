using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public enum AmountType : byte
    {
        [Display(Name="Money amount")]
        Money = 0,

        [Display(Name="Count")]
        Amount = 1
    }
}

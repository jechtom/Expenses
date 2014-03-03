using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Expenses.BL
{
    public class ExpenseIcon
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}

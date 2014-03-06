using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Contracts
{
    public class FileDataDto
    {
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public string UniqueName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Comment
    {
        public int IdComment { get; set; }
        public int IdCustomer { get; set; }
        public string TitleComment { get; set; }
        public string ContentComment { get; set; }
        public Decimal Star { get; set; }
        public string CategoryComment { get; set; }
    }
}

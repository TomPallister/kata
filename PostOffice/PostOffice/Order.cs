using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}

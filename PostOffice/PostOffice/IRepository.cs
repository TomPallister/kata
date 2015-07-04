using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    public interface IRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Supplier> Suppliers { get; }
        IQueryable<UnavailableDays> UnavailableDays { get; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    public class Repository : IRepository
    {
        public IQueryable<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product(){Id = 1, Name = "Birthday Card", SupplierId = 1},
                    new Product(){Id = 2, Name = "Flowers", SupplierId = 2}
                }.AsQueryable();
            }
        }

        public IQueryable<Supplier> Suppliers
        {
            get
            {
                return new List<Supplier>()
                {
                    new Supplier(){Name = "Laura's Cards", Id = 1, DeliveryDays = 1},
                    new Supplier(){Name = "Laura's Flowers", Id = 2, DeliveryDays = 2}
                }.AsQueryable();
            }
        }

        public IQueryable<UnavailableDays> UnavailableDays
        {
            get
            {
                return new List<UnavailableDays>()
                {
                    new UnavailableDays() {DayUnavailable = DateTime.Parse("05/07/2015"), SupplierId = 2},
                    new UnavailableDays() {DayUnavailable = DateTime.Parse("06/07/2015"), SupplierId = 2},
                }.AsQueryable();
            }
        }
    }
}

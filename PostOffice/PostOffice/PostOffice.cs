using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    public class PostOffice : IPostOffice
    {
        private readonly IRepository _repository;

        public PostOffice(IRepository repository)
        {
            _repository = repository;
        }
        public DateTime? GetDespatchDate(Order order)
        {
            var suppliersForThisOrder = _repository.Suppliers.Where(x => order.Products.Any(y => y.SupplierId == x.Id));
            var maxDeliveryDay = suppliersForThisOrder.Max(x => x.DeliveryDays);
            var unavailableDeliveryDaysForTheSuppliersInThisOrder =
                _repository.UnavailableDays.Where(x => suppliersForThisOrder.Any(y => y.Id == x.SupplierId));    
            while (true)
            {
                if (!unavailableDeliveryDaysForTheSuppliersInThisOrder.Any(
                        x => x.DayUnavailable.Date == order.DateOfOrder.Date.AddDays(maxDeliveryDay)))
                {
                    return order.DateOfOrder.Date.AddDays(maxDeliveryDay);
                }
                maxDeliveryDay++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PostOffice
{
    [TestFixture]
    public class Tests
    {
        private IRepository _repository;
        private IPostOffice _postOffice;

        [SetUp]
        public void set_up()
        {
            _repository = new Repository();
            _postOffice = new PostOffice(_repository);
        }

        [Test]
        public void can_order_single_product_advances_despatch_date_by_one_day()
        {
            var product = _repository.Products.FirstOrDefault(x => x.Name.ToLower().Contains("card"));
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>() {product},
                DateOfOrder = DateTime.Now
            };
            var despatchDate = _postOffice.GetDespatchDate(order);
            despatchDate.Should().Be(order.DateOfOrder.Date.AddDays(1));
        }

        [Test]
        public void can_order_two_product_advances_despatch_date_by_two_days()
        {
            var card = _repository.Products.FirstOrDefault(x => x.Name.ToLower().Contains("card"));
            var flowers = _repository.Products.FirstOrDefault(x => x.Name.ToLower().Contains("flowers"));
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>() { card, flowers },
                DateOfOrder = DateTime.Parse("01/07/2015")
            };
            var despatchDate = _postOffice.GetDespatchDate(order);
            despatchDate.Should().Be(order.DateOfOrder.Date.AddDays(2));
        }

        [Test]
        public void despatch_date_advances_correctly_when_day_unavailable()
        {
            var flowers = _repository.Products.FirstOrDefault(x => x.Name.ToLower().Contains("flowers"));
            var order = new Order
            {
                Id = 1,
                Products = new List<Product>() { flowers },
                DateOfOrder = DateTime.Parse("03/07/2015")
            };
            var despatchDate = _postOffice.GetDespatchDate(order);
            despatchDate.Should().Be(order.DateOfOrder.Date.AddDays(4));
            
        }
    }
}

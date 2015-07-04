using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RateCalculation.Domain.Model;
using RateCalculation.Infrastructure.Repository;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Makes sure we can persist lenders
    /// </summary>
    [TestFixture]
    public class LenderRepositoryTests
    {
        /// <summary>
        /// being tested
        /// </summary>
        private ILenderRepository _marketRepository;

        /// <summary>
        /// Sets up the tests
        /// </summary>
        [SetUp]
        public void set_up()
        {
            _marketRepository = new StubLenderRepository(new List<Lender>
            {
                new Lender("Bob", 0.075, 640),
                new Lender("Jane", 0.069, 480),
                new Lender("Fred", 0.071, 520),
                new Lender("Mary", 0.104, 170),
                new Lender("John", 0.081, 320),
                new Lender("Dave", 0.074, 140),
                new Lender("Angela", 0.071, 60)
            });
        }

        /// <summary>
        /// Makes sure we can store and find the lender we stored
        /// </summary>
        [Test]
        public void can_store_and_find_a_lender()
        {
            //set up        
            var newLender = new Lender("Tom", 0.109, 450);
            //act
            _marketRepository.Store(newLender);
            //assert
            var storedLender = _marketRepository.FindBy(x => x.Name == newLender.Name).FirstOrDefault();
            storedLender.Name.Should().Be(newLender.Name);
            storedLender.Available.Should().Be(newLender.Available);
            storedLender.Available.Should().Be(newLender.Available);
        }

        /// <summary>
        /// Makes sure we can store a list of lenders
        /// </summary>
        [Test]
        public void can_store_a_list_of_lenders()
        {
            //set up        
            List<Lender> lenders = new List<Lender>
            {
                new Lender("Tom", 0.109, 450),
                new Lender("Laura", 0.609, 480),
            };
            //act
            _marketRepository.Store(lenders);
            //assert
            var storedLender = _marketRepository.FindBy(x => x.Name == lenders[0].Name).FirstOrDefault();
            storedLender.Name.Should().Be(lenders[0].Name);
            storedLender.Available.Should().Be(lenders[0].Available);
            storedLender.Available.Should().Be(lenders[0].Available);
            storedLender = _marketRepository.FindBy(x => x.Name == lenders[1].Name).FirstOrDefault();
            storedLender.Name.Should().Be(lenders[1].Name);
            storedLender.Available.Should().Be(lenders[1].Available);
            storedLender.Available.Should().Be(lenders[1].Available);
        }
    }
}

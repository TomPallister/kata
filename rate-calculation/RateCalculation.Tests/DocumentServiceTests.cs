using System;
using FluentAssertions;
using NUnit.Framework;
using RateCalculation.Infrastructure.Console;

namespace RateCalculation.Tests
{
    /// <summary>
    /// Tests for teh document service.
    /// </summary>
    public class DocumentServiceTests
    {
        /// <summary>
        /// The thing being tested
        /// </summary>
        private IDocumentService _documentService;

        [SetUp]
        public void set_up()
        {
            //We are testing the csv reader console service
            _documentService = new CsvReaderConsoleService();    
        }

        /// <summary>
        /// This tests should prove that we can get lenders from a document in the expected state
        /// It is something of a happy path test
        /// </summary>
        [Test]
        public void can_get_lenders_from_document()
        {
            //setup
            var documentLocation = "market.csv";
            //act
            var lenders = _documentService.GetLendersFromDocument(documentLocation);
            //assert
            lenders.Count.Should().Be(7);
            //bob
            lenders.Should().Contain(x => x.Name == "Bob");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.075) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 640);
            //jane
            lenders.Should().Contain(x => x.Name == "Jane");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.069) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 480);
            //fred
            lenders.Should().Contain(x => x.Name == "Fred");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.071) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 520);
            //mary
            lenders.Should().Contain(x => x.Name == "Mary");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.104) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 170);
            //john
            lenders.Should().Contain(x => x.Name == "John");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.081) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 320);
            //dave
            lenders.Should().Contain(x => x.Name == "Dave");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.074) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 140);
            //angela
            lenders.Should().Contain(x => x.Name == "Angela");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.071) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 60);
        }

        /// <summary>
        /// This test looks after the getsafevalue extension method on the csv reader/
        /// It will read out all the rows and use a default value if it fails
        /// we then need to handle that value
        /// </summary>
        [Test]
        public void can_get_market_with_bad_document()
        {
            //setup
            var documentLocation = "bad_market.csv";
            //act
            var lenders = _documentService.GetLendersFromDocument(documentLocation);
            //assert
            lenders.Count.Should().Be(8);
            //bob
            lenders.Should().Contain(x => x.Name == "Bob");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.075) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 640);
            //jane
            lenders.Should().Contain(x => x.Name == "Jane");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.069) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 480);
            //fred
            lenders.Should().Contain(x => x.Name == "Fred");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.071) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 520);
            //mary
            lenders.Should().Contain(x => x.Name == "Mary");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.104) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 170);
            //john
            lenders.Should().Contain(x => x.Name == "John");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.081) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 320);
            //dave
            lenders.Should().Contain(x => x.Name == "Dave");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.074) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 140);
            //angela
            lenders.Should().Contain(x => x.Name == "Angela");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0.071) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 60);
            //Could not load name from Document
            lenders.Should().Contain(x => x.Name == "BadName");
            lenders.Should().Contain(x => Math.Abs(x.Rate - 0) < double.Epsilon);
            lenders.Should().Contain(x => x.Available == 0);
        }
    }
}

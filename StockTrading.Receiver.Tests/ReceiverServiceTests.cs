using NUnit.Framework;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Methods;
using StockTrading.Receiver.Models;

namespace StockTrading.Receiver.Tests
{
    public class ReceiverServiceTests
    {
        Mapper _mapper = new Mapper();

        [Test]
        public void GetAllFromDatabase_ReturnResponce()
        {
            // Arrange
            // Create sample data
            var testData = new StockRespons
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns 
            var result = _mapper.ToDocument(testData);

            // Assert

            Assert.IsNotNull(result);
        }
        [Test]
        public void GetStockByName_ReturnResponce()
        {
            // Arrange
            // Create sample data
            var testData = new StockRespons
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns 

            var result = _mapper.ToDocument(testData);

            // Assert

            Assert.IsNotNull(result);

        }

        [Test]
        public void AddStocks_SeeAdded()
        {
            // Arrange
            // Create sample data

            var testData = new StockRespons
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns  

            var response = _mapper.ToDocument(testData);

            // Assert

            Assert.IsNotNull(response);

        }

        [Test]
        public void DeleteStocks_SeeAdded()
        {
            // Arrange
            // Create sample data

            var testData = new StockRespons
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns  

            var response = _mapper.ToDocument(testData);

            // Assert

            Assert.IsNotNull(response);

        }
        [Test]
        public void UpdateStock_SeeUpdated()
        {
            // Arrange
            // Create sample data

            var testData = new StockRespons
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns with updated price 

            var result = _mapper.ToDocument(testData);

            // Assert

            Assert.IsNotNull(result);

        }
    }
}

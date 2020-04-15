using NUnit.Framework;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs.Models;
using StockTrading.Sender.Mappers;

namespace StockTrading.Sender.Tests
{
    public class SenderServiceTests
    {

        Mapper _mapper = new Mapper();

        [Test]
        public void GetAllFromDatabase_ReturnResponce()
        {
            // Arrange
            // Create sample data
            var testData = new StockDB
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns 
            var result = _mapper.ToStockContract(testData);

            // Assert

            Assert.IsNotNull(result);
        }
        [Test]
        public void GetItem_ReturnResponce()
        {
            // Arrange
            // Create sample data
            var testData = new StockDB
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            // Act
            // Test if mapper returns 

            var result = _mapper.ToStockContract(testData);

            // Assert

            Assert.IsNotNull(result);

        }

        [Test]
        public void AddStocks_SeeAdded()
        {
            // Arrange
            // Create sample data

            var stockRequest = new StockRequest
            {
                Name = "test-Stock",
                Price = 1000,
            };

            // Act
            // Test if mapper returns  

            var response = _mapper.ToStockDBModel(stockRequest);

            // Assert

            Assert.IsNotNull(response);

        }
        [Test]
        public void UpdateStock_SeeUpdated()
        {
            // Arrange
            // Create sample data

            var testData = new StockDB
            {
                Name = "test-Stock",
                Price = 1000,
                LastUpdated = "09/04/2020 10:36:52"
            };

            var stockRequest = new StockRequest
            {
                Name = "test-Stock",
                Price = 2000,
            };

            // Act
            // Test if mapper returns with updated price 

            var result = _mapper.ToStockDBModel(testData ,stockRequest);

            // Assert

            Assert.AreEqual(2000, result.Price);

        }

    }
}
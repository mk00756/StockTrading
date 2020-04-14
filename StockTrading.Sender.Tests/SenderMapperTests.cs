using Amazon.DynamoDBv2.DocumentModel;
using NUnit.Framework;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs;
using StockTrading.Sender.Libs.Models;
using StockTrading.Sender.Mappers;
using System.Collections.Generic;

namespace StockTrading.Sender.Tests
{
    public class SenderMapperTests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void Mapper_ToStockContract_ReturnsStockResponse()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var item = new StockDB();
            item.Name = "SendStockTest";
            item.Price = 123.45f;
            item.LastUpdated = currentTime;

            var mapper = new Mapper();

            StockResponse expectedResponse = new StockResponse
            {
                Name = "SendStockTest",
                Price = 123.45f,
                LastUpdated = currentTime
            };

            StockResponse result;

            // Act
            result = mapper.ToStockContract(item);

            // Assert
            Assert.AreEqual(expectedResponse.Name, result.Name);
            Assert.AreEqual(expectedResponse.Price, result.Price);
            Assert.AreEqual(expectedResponse.LastUpdated, result.LastUpdated);
        }

        [Test]
        public void Mapper_ToStockDBModel_ReturnsStockDB()
        {
            // Arrange

            StockRequest stockDB = new StockRequest
            {
                Name = "SendStockTest",
                Price = 123.45f
            };

            var expectedStockDB = new StockDB();
            expectedStockDB.Name = "SendStockTest";
            expectedStockDB.Price = 123.45f;
            expectedStockDB.LastUpdated = System.DateTime.Now.ToString();

            var mapper = new Mapper();

            StockDB result;

            // Act
            result = mapper.ToStockDBModel(stockDB);

            // Assert
            Assert.AreEqual(expectedStockDB.Name, result.Name);
            Assert.AreEqual(expectedStockDB.Price, result.Price);
        }

        [Test]
        public void Mapper_ToStockDBModelOverride_ReturnsStockDB()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();

            StockDB stockDB = new StockDB
            {
                Name = "StockDBName",
                Price = 111.22f,
                LastUpdated = currentTime
            };

            StockRequest stockRequest = new StockRequest
            {
                Name = "StockRequestName",
                Price = 222.33f
            };

            var expectedStockDB = new StockDB();
            expectedStockDB.Name = "StockDBName";
            expectedStockDB.Price = 222.33f;
            expectedStockDB.LastUpdated = currentTime;

            var mapper = new Mapper();

            StockDB result;

            // Act
            result = mapper.ToStockDBModel(stockDB, stockRequest);

            // Assert
            Assert.AreEqual(expectedStockDB.Name, result.Name);
            Assert.AreEqual(expectedStockDB.Price, result.Price);
        }
    }
}
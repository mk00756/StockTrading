using Amazon.DynamoDBv2.DocumentModel;
using NUnit.Framework;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Methods;
using System.Collections.Generic;

namespace StockTrading.Receiver.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Mapper_ToStockContract_ReturnsStockResponse()
        {
            // Arrange
            var item = new Document();
            item["Name"] = "STOCK";
            item["Price"] = 123.45f;
            item["LastUpdated"] = System.DateTime.Now.ToString();

            var mapper = new Mapper();

            StockRespons expectedResponse = new StockRespons();
            expectedResponse.Name = "STOCK";
            expectedResponse.Price = 123.45f;
            expectedResponse.LastUpdated = System.DateTime.Now.ToString();

            StockRespons result;
            // Act
            result = mapper.ToStockContract(item);

            // Assert
            Assert.AreEqual(expectedResponse.Name, result.Name);
            Assert.AreEqual(expectedResponse.Price, result.Price);
            Assert.AreEqual(expectedResponse.LastUpdated, result.LastUpdated);
        }
    }
}
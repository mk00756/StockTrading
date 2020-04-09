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
        public void Setup(){ }

        [Test]
        public void Mapper_ToStockContract_ReturnsStockResponse()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var item = new Document();
            item["Name"] = "STOCK";
            item["Price"] = 123.45f;
            item["LastUpdated"] = currentTime;

            var mapper = new Mapper();

            StockRespons expectedResponse = new StockRespons();
            expectedResponse.Name = "STOCK";
            expectedResponse.Price = 123.45f;
            expectedResponse.LastUpdated = currentTime;

            StockRespons result;

            // Act
            result = mapper.ToStockContract(item);

            // Assert
            Assert.AreEqual(expectedResponse.Name, result.Name);
            Assert.AreEqual(expectedResponse.Price, result.Price);
            Assert.AreEqual(expectedResponse.LastUpdated, result.LastUpdated);
        }

        [Test]
        public void Mapper_ToDocument_ReturnsDocument()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();

            StockRespons stockResponse = new StockRespons();
            stockResponse.Name = "STOCK";
            stockResponse.Price = 123.45f;
            stockResponse.LastUpdated = currentTime;

            var expectedDocument = new Document();
            expectedDocument["Name"] = "STOCK";
            expectedDocument["Price"] = 123.45f;
            expectedDocument["LastUpdated"] = currentTime;

            var mapper = new Mapper();

            Document result;

            // Act
            result = mapper.ToDocument(stockResponse);

            // Assert
            Assert.AreEqual(expectedDocument["Name"], result["Name"]);
            Assert.AreEqual(expectedDocument["Price"], result["Price"]);
            Assert.AreEqual(expectedDocument["LastUpdated"], result["LastUpdated"]);
        }
    }
}
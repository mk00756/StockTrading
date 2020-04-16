using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using NUnit.Framework;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Methods;
using StockTrading.Receiver.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Tests
{
    public class ReceiverRepositoyTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public async Task StockRep_GetAllItems_ReturnsAllItems()
        {
            // Arrange
            var stockRep = new StockRepository(new AmazonDynamoDBClient());
            // Act
            var result = await stockRep.GetAllItems();
            // Assert
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.IsNotNull(enumerator.Current["Name"]);
            }
        }

        [Test]
        public async Task StockRep_GetStockByName_ReturnsNamedItem()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockRepository(new AmazonDynamoDBClient());
            var mapper = new Mapper();

            Document newStock = new Document
            {
                ["Name"] = "GETSTOCK",
                ["Price"] = 112.21,
                ["LastUpdated"] = currentTime
            };

            var mappedStock = mapper.ToStockContract(newStock);
            // Act
            await stockRep.AddStock(newStock);
            var result = mapper.ToStockContract(await stockRep.GetStockByName("GETSTOCK"));
            // Assert
            Assert.AreEqual(mappedStock.Name, result.Name);
            Assert.AreEqual(mappedStock.Price, result.Price);
            Assert.AreEqual(mappedStock.LastUpdated, result.LastUpdated);
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }

        [Test]
        public async Task StockRep_AddStock_AddsStock()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockRepository(new AmazonDynamoDBClient());
            var mapper = new Mapper();

            Document newStock = new Document
            {
                ["Name"] = "NEWSTOCK",
                ["Price"] = 135.79,
                ["LastUpdated"] = currentTime
            };

            var mappedStock = mapper.ToStockContract(newStock);
            // Act
            await stockRep.AddStock(newStock);
            var result = mapper.ToStockContract(await stockRep.GetStockByName(newStock["Name"]));
            // Assert
            Assert.AreEqual(mappedStock.Name, result.Name);
            Assert.AreEqual(mappedStock.Price, result.Price);
            Assert.AreEqual(mappedStock.LastUpdated, result.LastUpdated);
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }

        [Test]
        public async Task StockRep_DeleteStock_DeletesStock()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockRepository(new AmazonDynamoDBClient());

            Document testStock = new Document
            {
                ["Name"] = "DELETEME",
                ["Price"] = 112.23,
                ["LastUpdated"] = currentTime
            };
            // Act
            await stockRep.AddStock(testStock);
            var result1 = await stockRep.GetStockByName(testStock["Name"]);
            await stockRep.DeleteStock(testStock);
            var result2 = await stockRep.GetStockByName(testStock["Name"]);
            // Assert
            Assert.AreNotEqual(result1, result2);
        }

        [Test]
        public async Task StockRep_UpdateStock_UpdatesStock()
        {
            // Arrange
            var stockRep = new StockRepository(new AmazonDynamoDBClient());

            Document oldStock = new Document
            {
                ["Name"] = "UPDATEME",
                ["Price"] = 000.00,
                ["LastUpdated"] = System.DateTime.Now.ToString()
            };

            Document newStock = new Document
            {
                ["Name"] = "UPDATEME",
                ["Price"] = 123.45,
                ["LastUpdated"] = System.DateTime.Now.ToString()
            };
            // Act
            await stockRep.AddStock(oldStock);
            var result1 = await stockRep.GetStockByName(oldStock["Name"]);
            await stockRep.UpdateStock(newStock);
            var result2 = await stockRep.GetStockByName(newStock["Name"]);
            // Assert
            Assert.AreNotEqual(result1["Price"], result2["Price"]);
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }
    }
}
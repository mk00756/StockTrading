using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using NUnit.Framework;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs;
using StockTrading.Sender.Libs.Repositories;
using StockTrading.Sender.Libs.Models;
using StockTrading.Sender.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Tests
{
    public class RepositoriesTests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public async Task GetAllItems_Test()
        {
            // Arrange
            var stockRep = new StockTradingRepository(new AmazonDynamoDBClient());
            
            // Act
            var result = await stockRep.GetAllItems();
            
            // Assert
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.IsNotNull(enumerator.Current);
            }
        }

        [Test]
        public async Task GetItem_Test()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockTradingRepository(new AmazonDynamoDBClient());
            var mapper = new Mapper();

            var newStock = new StockDB();
            newStock.Name = "SendStockTest";
            newStock.Price = 123.45f;
            newStock.LastUpdated = currentTime;

            var mappedStock = mapper.ToStockContract(newStock);
            
            // Act
            await stockRep.AddStock(newStock);
            var result = mapper.ToStockContract(await stockRep.GetItem("SendStockTest"));
           
            // Assert
            Assert.AreEqual(mappedStock.Name, result.Name);
            Assert.AreEqual(mappedStock.Price, result.Price);
            Assert.AreEqual(mappedStock.LastUpdated, result.LastUpdated);
            
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }

        [Test]
        public async Task AddStock_Test()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockTradingRepository(new AmazonDynamoDBClient());
            var mapper = new Mapper();

            var newStock = new StockDB();
            newStock.Name = "SendStockTest";
            newStock.Price = 123.45f;
            newStock.LastUpdated = currentTime;

            var mappedStock = mapper.ToStockContract(newStock);
            
            // Act
            await stockRep.AddStock(newStock);
            var result = mapper.ToStockContract(await stockRep.GetItem("SendStockTest"));
            
            // Assert
            Assert.AreEqual(mappedStock.Name, result.Name);
            Assert.AreEqual(mappedStock.Price, result.Price);
            Assert.AreEqual(mappedStock.LastUpdated, result.LastUpdated);
            
            // Clean-up
            await stockRep.DeleteStock(newStock);

        }

        [Test]
        public async Task DeleteStock_Test()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockTradingRepository(new AmazonDynamoDBClient());

            var newStock = new StockDB();
            newStock.Name = "SendStockTest";
            newStock.Price = 123.45f;
            newStock.LastUpdated = currentTime;

            // Act
            await stockRep.AddStock(newStock);
            var result1 = await stockRep.GetItem(newStock.Name);
            await stockRep.DeleteStock(newStock);
            var result2 = await stockRep.GetItem(newStock.Name);
            
            // Assert
            Assert.AreNotEqual(result1, result2);

        }

        [Test]
        public async Task UpdateStock_Test()
        {
            // Arrange
            var stockRep = new StockTradingRepository(new AmazonDynamoDBClient());

            var oldStock = new StockDB();
            oldStock.Name = "SendStockTest";
            oldStock.Price = 123.45f;
            oldStock.LastUpdated = System.DateTime.Now.ToString();

            var newStock = new StockDB();
            newStock.Name = "SendStockTest";
            newStock.Price = 678.90f;
            newStock.LastUpdated = System.DateTime.Now.ToString();

            // Act
            await stockRep.AddStock(oldStock);
            var result1 = await stockRep.GetItem(oldStock.Name);
            await stockRep.UpdateStock(newStock);
            var result2 = await stockRep.GetItem(newStock.Name);
            // Assert
            Assert.AreNotEqual(result1.Price, result2.Price);
            
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }
    }
}
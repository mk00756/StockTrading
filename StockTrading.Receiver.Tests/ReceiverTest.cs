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
    public class Tests
    {
        [SetUp]
        public void Setup(){ }

        [Test]
        public void Mapper_ToStockContract_ReturnsStockResponse()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var item = new Document
            {
                ["Name"] = "STOCK",
                ["Price"] = 123.45,
                ["LastUpdated"] = currentTime
            };

            var mapper = new Mapper();

            StockRespons expectedResponse = new StockRespons
            {
                Name = "STOCK",
                Price = 123.45,
                LastUpdated = currentTime
            };

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

            StockRespons stockResponse = new StockRespons
            {
                Name = "STOCK",
                Price = 123.45,
                LastUpdated = currentTime
            };

            var expectedDocument = new Document
            {
                ["Name"] = "STOCK",
                ["Price"] = 123.45,
                ["LastUpdated"] = currentTime
            };

            var mapper = new Mapper();

            Document result;

            // Act
            result = mapper.ToDocument(stockResponse);
            
            // Assert
            Assert.AreEqual(expectedDocument["Name"], result["Name"]);
            Assert.AreEqual(expectedDocument["Price"], result["Price"]);
            Assert.AreEqual(expectedDocument["LastUpdated"], result["LastUpdated"]);
        }

        [Test]
        public void Mapper_ToStockContract_ReturnsStocks()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();

            var item1 = new Document();
            item1["Name"] = "STOCK1";
            item1["Price"] = 123.45;
            item1["LastUpdated"] = currentTime;

            var item2 = new Document();
            item2["Name"] = "STOCK2";
            item2["Price"] = 111.11;
            item2["LastUpdated"] = currentTime;

            List<Document> itemList = new List<Document>();
            itemList.Add(item1);
            itemList.Add(item2);

            StockRespons expectedItem1 = new StockRespons();
            expectedItem1.Name = "STOCK1";
            expectedItem1.Price = 123.45;
            expectedItem1.LastUpdated = currentTime;

            StockRespons expectedItem2 = new StockRespons();
            expectedItem2.Name = "STOCK2";
            expectedItem2.Price = 111.11;
            expectedItem2.LastUpdated = currentTime;

            List<StockRespons> expectedItemList = new List<StockRespons>
            {
                expectedItem1,
                expectedItem2
            };

            var mapper = new Mapper();

            IEnumerable<StockRespons> result;

            // Act
            result = mapper.ToStockContract(itemList);

            // Assert
            var enumerator = result.GetEnumerator();
            int count = -1;
            while(enumerator.MoveNext())
            {
                count++;
                Assert.AreEqual(expectedItemList[count].Name, enumerator.Current.Name);
                Assert.AreEqual(expectedItemList[count].Price, enumerator.Current.Price);
                Assert.AreEqual(expectedItemList[count].LastUpdated, enumerator.Current.LastUpdated);
            }
        }

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

            Document newStock = new Document
            {
                ["Name"] = "GETSTOCK",
                ["Price"] = 112.21,
                ["LastUpdated"] = currentTime
            };
            // Act
            await stockRep.AddStock(newStock);
            var result = await stockRep.GetStockByName("GETSTOCK");
            // Assert
            Assert.AreEqual(result["Name"], newStock["Name"]);
            Assert.AreEqual(result["Price"], newStock["Price"]);
            Assert.AreEqual(result["LastUpdated"], newStock["LastUpdated"]);
            // Clean-up
            await stockRep.DeleteStock(newStock);
        }

        [Test]
        public async Task StockRep_AddStock_AddsStock()
        {
            // Arrange
            string currentTime = System.DateTime.Now.ToString();
            var stockRep = new StockRepository(new AmazonDynamoDBClient());

            Document newStock = new Document
            {
                ["Name"] = "NEWSTOCK",
                ["Price"] = 135.79,
                ["LastUpdated"] = currentTime
            };
            // Act
            await stockRep.AddStock(newStock);
            var result = await stockRep.GetStockByName(newStock["Name"]);
            // Assert
            Assert.AreEqual(result["Name"], newStock["Name"]);
            Assert.AreEqual(result["Price"], newStock["Price"]);
            Assert.AreEqual(result["LastUpdated"], newStock["LastUpdated"]);
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
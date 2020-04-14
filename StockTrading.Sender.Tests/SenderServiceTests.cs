using Amazon.DynamoDBv2.DocumentModel;
using NUnit.Framework;
using StockTrading.Sender.Services;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs;
using StockTrading.Sender.Libs.Models;
using StockTrading.Sender.Libs.Repositories;
using StockTrading.Sender.Mappers;
using System.Collections.Generic;

namespace StockTrading.Sender.Tests
{
    public class SenderServiceTests
    {
        [SetUp]
        public void Setup()
        {
            //Setup new instance of senderservice here
            IStockTradingRepository TestRepository = new StockTradingRepository()
        }

        [Test]
        public void GetAllFromDatabase_ReturnResponce()
        {
            // Arrange


            // Act


            // Assert

        }

        public void GetItem_ReturnResponce()
        {
            // Arrange


            // Act


            // Assert

        }

        public void AddStocks_SeeAdded()
        {
            // Arrange


            // Act


            // Assert

        }

        public void UpdateStock_SeeUpdated()
        {
            // Arrange


            // Act


            // Assert

        }

        public void RemoveStock_CheckRemoved()
        {
            // Arrange


            // Act


            // Assert

        }
    }
}
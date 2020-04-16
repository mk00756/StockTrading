using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using NUnit.Framework;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using StockTrading.Receiver.Contracts;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs;
using StockTrading.Sender.Libs.MessageBroker;
using StockTrading.Sender.Libs.Models;
using StockTrading.Sender.Mappers;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Sender.Tests
{
    public class MessageBrokerTests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void RabbitMQClient_Test()
        {
            // Arrange
            RabbitMQClient MQClient = new RabbitMQClient("Test_Queue", "stock.test");
            StockDB stockDB = new StockDB 
            {
                Name = "TESTNAME",
                Price = 123.99f,
                LastUpdated = System.DateTime.Now.ToString()
            };
            // Act
            MQClient.SendMethod(stockDB, "stock.test");
            var response = ReceiveMessage();
            // Assert
            Assert.AreEqual(stockDB.Name, response.Name);
            Assert.AreEqual(stockDB.Price, response.Price);
            Assert.AreEqual(stockDB.LastUpdated, response.LastUpdated);
            // Clean-up
            MQClient.Close();
        }

        private StockRespons ReceiveMessage()
        {
            string AllQueueName = "Test_Queue";
            string ExchangeName = "Topic_Exchange";

            ConnectionFactory _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            IConnection _connection;

            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    // Create and declare queue
                    channel.ExchangeDeclare(ExchangeName, "topic");
                    channel.QueueDeclare(AllQueueName, true, false, false, null);
                    channel.QueueBind(AllQueueName, ExchangeName, "stock.test");
                    BasicGetResult status = channel.BasicGet(AllQueueName, false);

                    Subscription subscription = new Subscription(channel, AllQueueName, true);

                    // Read from queue
                    BasicDeliverEventArgs deliveryArguments = subscription.Next();
                    var body = deliveryArguments.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var stock = JsonConvert.DeserializeObject<StockRespons>(message);
                    subscription.Ack(deliveryArguments);
                    _connection.Close();
                    return stock;                    
                }
            }
        }
    }
}
using Newtonsoft.Json;
using RabbitMQ.Client;
using StockTrading.Sender.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Sender.Libs.MessageBroker
{
    public class RabbitMQClient
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        private const string ExchangeName = "Topic_Exchange";
        private const string AllQueueName = "AllTopic_Queue";
        private const string RoutingKey = "";



        public RabbitMQClient()
        {
            CreateConnection();
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(ExchangeName, "topic");
            _model.QueueDeclare(AllQueueName, true, false, false, null);

            _model.QueueBind(AllQueueName, ExchangeName, "stock.add");


        }

        public void SendMethod(StockDB stockDB)
        {
            SendMessage(Serialize(stockDB),"stock.add");

        }

        public void SendMessage(byte[] message, string routingKey)
        {

            _model.BasicPublish(exchange: ExchangeName,
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: message);
        }

        private static byte[] Serialize(StockDB stockDB)
        {
            var jsonified = JsonConvert.SerializeObject(stockDB);
            return Encoding.ASCII.GetBytes(jsonified);

        }
        public void Close()
        {
            _connection.Close();
        }
    }
}

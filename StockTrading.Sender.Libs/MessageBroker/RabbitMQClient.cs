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
        private string QueueName = "";
        private string RoutingKey = "";

        public RabbitMQClient(string queueName, string routingKey)
        {
            QueueName = queueName;
            RoutingKey = routingKey;
            CreateConnection(queueName, routingKey);
        }

        private static void CreateConnection(string queueName, string routingKey)
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
            _model.QueueDeclare(queueName, true, false, false, null);

            _model.QueueBind(queueName, ExchangeName, routingKey);


        }

        public void SendMethod(StockDB stockDB, string routingKey)
        {
            SendMessage(Serialize(stockDB), routingKey);
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

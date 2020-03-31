﻿using RabbitMQ.Client;
using StockTrading.Sender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Sender.Libs.MessageBroker
{
    public class SendMQ
    {
        public class SendMQ(StockDB)
            {
            public int MyProperty { get; set; }
    }

        public void SendStock(StockDB stockDB)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "stocks", type: ExchangeType.Fanout);

                var message = GetMessage(stockDB);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "stocks",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }

        private static string GetMessage(StockDB stockDB)
        {
            return ($"{stockDB.Name} {stockDB.Price}");

        }

    }
}

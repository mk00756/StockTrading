using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace StockTrading.Libs
{
    public class EmitStock
    { 
        public void SendStock(string msg)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "stocks", type: ExchangeType.Fanout);

            var message = msg;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "stocks",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

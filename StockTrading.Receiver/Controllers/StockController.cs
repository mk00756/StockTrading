using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using StockTrading.Receiver.Models;
using StockTrading.Receiver.Services;
using StockTraiding.Receaver.Contracts;
using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client.Events;

namespace StockTrading.Receiver.Controllers {

    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {

        private IModel _model;
        private IConnection _conection;
        private ConnectionFactory _factory;

        private const string QueueName = "QueName";

        public readonly IStockService _stockServer;
        public StockController(IStockService stockService) {
            _stockServer = stockService;
        }

        private void ReceiveMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "stocks", type: ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "stocks",
                              routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var stock = JsonConvert.DeserializeObject<StockDB>(message);
                // TODO: Further process the message

            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        [HttpGet]
        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }
        //[HttpGet]
        //[Route("{StockName}")]
        //public async Task<StockRespons> GetItemsFromDatabaseByName(string StockName) {
        //    var result = await _stockServer.GetStockByName(StockName);
        //    return result;
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using StockTrading.Receiver.Models;
using StockTrading.Receiver.Services;
using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client.Events;
using StockTrading.Receiver.Contracts;

namespace StockTrading.Receiver.Controllers {

    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {

        public readonly IStockService _stockServer;

        public StockController(IStockService stockService) {
            _stockServer = stockService;
            ReceiveMessage();
        }
        private void ReceiveMessage() {
            //Vreates the conmection
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "stocks", type: ExchangeType.Fanout);
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,exchange: "stocks",routingKey: "");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var stock = JsonConvert.DeserializeObject<StockDB>(message);
                // TODO: Further process the message

            };
            channel.BasicConsume(queue:queueName,autoAck: true,consumer:consumer);
        }
        [HttpGet]
        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }

        //Posts from RabbitMQ
        private async Task<IActionResult> PostFromRabbitMQ(StockRequest stock) {
            await _stockServer.AddStock(stock);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStocks([FromBody] StockRequest stockRequest) {
            await _stockServer.AddStock(stockRequest);
            return Ok();
        }
    }
}
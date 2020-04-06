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
using RabbitMQ.Client.MessagePatterns;
using StockTrading.Receiver.MessageBroker;

namespace StockTrading.Receiver.Controllers {

    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {

        public readonly IStockService _stockServer;
        private const string ExchangeName = "Topic_Exchange";
        private const string AllQueueName = "AllTopic_Queue";
        private string returnMessage = "";

        public StockController(IStockService stockService) {
            _stockServer = stockService;
            //ReceiveMessage();
        }
        private void ReceiveMessage() {
            //Vreates the conmection
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(ExchangeName, "topic");
            channel.QueueDeclare(AllQueueName, true, false, false, null);

            channel.QueueBind(AllQueueName, ExchangeName, "stocks.add");
            channel.BasicQos(0, 10, false);


            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) => {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var stock = JsonConvert.DeserializeObject<StockDB>(message);
                returnMessage = stock.ToString();

                // TODO: Further process the message

            };
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItemsFromDatabase() {
            //var result = await _stockServer.GetAllItemsFromDatabase();
            ReceiveMQ receive = new ReceiveMQ(_stockServer);
            receive.CreateConnection();
            await receive.ReceiveMessage();
            receive.Close();


            return Ok();
        }

        ////Posts from RabbitMQ
        //private async Task<IActionResult> PostFromRabbitMQ(StockRequest stock) {
        //    await _stockServer.AddStock(stock);
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddNewStocks([FromBody] StockRequest stockRequest) {
        //    await _stockServer.AddStock(stockRequest);
        //    return Ok();
        //}
    }
}
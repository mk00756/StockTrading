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
using StockTrading.Receiver.MessageBroker;

namespace StockTrading.Receiver.Controllers {

    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {

        public readonly IStockService _stockServer;

        public StockController(IStockService stockService) {
            _stockServer = stockService;
        }

        [HttpGet]
        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }

        //Posts from RabbitMQ
        private async Task<IActionResult> PostFromRabbitMQ(StockRespons stock) {
            await _stockServer.AddStock(stock);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStocks([FromBody] StockRespons stockRequest) {
            await _stockServer.AddStock(stockRequest);
            return Ok();
        }



        [HttpGet]
        [Route("/add")]
        public async Task<IActionResult> AddStock(string id)
        {
            //var result = await _stockServer.GetAllItemsFromDatabase();

            AddConsumer receive = new AddConsumer(_stockServer);
            receive.CreateConnection();
            await receive.ReceiveMessage();
            receive.Close();


            return Ok();
        }
        [HttpGet]
        [Route("/delete")]
        public async Task<IActionResult> DeleteStock(string id)
        {
            //var result = await _stockServer.GetAllItemsFromDatabase();
            DeleteConsumer receive = new DeleteConsumer(_stockServer);
            receive.CreateConnection();
            await receive.ReceiveMessage();
            receive.Close();

            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver.Services;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.MessageBroker;
using StockTrading.Receiver.Consumers;
using System.Threading;

namespace StockTrading.Receiver.Controllers {

    [Route("Receiver")]
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

        [HttpGet]
        [Route("{name}")]
        public async Task<StockRespons> GetStockByNameItem(string name) {
            var result = await _stockServer.GetStockByName(name);
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

    }
}
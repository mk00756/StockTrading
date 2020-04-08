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

            //// initialise each consumer
            //AddConsumer add = new AddConsumer(_stockServer);
            //DeleteConsumer delete = new DeleteConsumer(_stockServer);
            //UpdateConsumer update = new UpdateConsumer(_stockServer);

            //// initialise each thread
            //Thread addThread = new Thread(new ThreadStart(add.ReceiveMessage));
            //Thread deleteThread = new Thread(new ThreadStart(delete.ReceiveMessage));
            //Thread updateThread = new Thread(new ThreadStart(update.ReceiveMessage));

            //// start each receiving connection to the queue
            //add.CreateConnection();
            //delete.CreateConnection();
            //update.CreateConnection();

            //// start each thread
            //addThread.Start();
            //deleteThread.Start();
            //updateThread.Start();
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



        //[HttpGet]
        //[Route("/add")]
        //public async Task<IActionResult> AddStock()
        //{
        //    var result = await _stockServer.GetAllItemsFromDatabase();

        //    AddConsumer receive = new AddConsumer(_stockServer);
        //    receive.CreateConnection();
        //    receive.ReceiveMessage();

        //    return Ok();
        //}
        //[HttpGet]
        //[Route("/update")]
        //public async Task<IActionResult> UpdateStock()
        //{
        //    var result = await _stockServer.GetAllItemsFromDatabase();
        //    UpdateConsumer receive = new UpdateConsumer(_stockServer);
        //    receive.CreateConnection();
        //    receive.ReceiveMessage();
        //    receive.Close();

        //    return Ok();
        //}
        //[HttpGet]
        //[Route("/delete")]
        //public async Task<IActionResult> DeleteStock()
        //{
        //    var result = await _stockServer.GetAllItemsFromDatabase();
        //    DeleteConsumer delete = new DeleteConsumer(_stockServer);
        //    delete.CreateConnection();
        //    delete.ReceiveMessage();
        //    delete.Close();

        //    return Ok();
        //}
    }
}
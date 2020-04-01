using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver.Services;
using StockTraiding.Receaver.Contracts;

namespace StockTrading.Receiver.Controllers {
    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {
        public readonly IStockService _stockServer;
        public StockController(IStockService stockService) => _stockServer = stockService;
        [HttpGet]
        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }
        [HttpGet]
        [Route("{StockName}")]
        public async Task<IEnumerable<StockRespons>> GetItemsFromDatabaseByName() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }
    }
}
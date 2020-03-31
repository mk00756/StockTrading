using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver.Services;

namespace StockTrading.Receiver.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase {
        public readonly IStockService _stockServer;

        public StockController(IStockService stockService) => _stockServer = stockService;
    }
}
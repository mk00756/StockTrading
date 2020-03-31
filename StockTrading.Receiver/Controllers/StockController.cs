using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver;
using StockTraiding;

namespace StockTrading.Receiver.Controllers {
    [Route("api/Reciver")]
    [ApiController]
    public class StockController : ControllerBase {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<StockRespons>> GetAllStocks() {

        }

    }
}
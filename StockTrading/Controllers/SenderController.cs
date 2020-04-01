using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Services;

namespace StockTrading.Sender.Controllers
{
    [Route("stocks")]
    public class SenderController : Controller
    {
        private readonly ISenderService _senderService;

        public SenderController(ISenderService senderService)
        {
            _senderService = senderService;
        }

        [HttpGet]
        public async Task<IEnumerable<StockResponse>> GetAllFromDatabase()
        {
            var results = await _senderService.GetAllFromDatabase();

            return results;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStocks([FromBody] StockRequest stockRequest)
        {
            await _senderService.AddStocks(stockRequest);
            return Ok();
        }

        //[HttpPatch]
        //[Route("{Name}")]
        //public async Task<IActionResult> UpdateStock(string name, [FromBody] StockRequest stockRequest)
        //{
        //    await _senderService.UpdateStock(name, stockRequest);
        //    return Ok();
        //}

        [HttpDelete]
        public async Task<IActionResult> RemoveStock([FromBody] string name)
        {
            await _senderService.RemoveStock(stockRequest);
        }
    }
}

//[HttpPost]
////[Route ("addstock")]
//public async Task<IActionResult> AddStock(string Name, double price)

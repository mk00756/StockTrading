﻿using System;
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

        [HttpGet]
        [Route("{name}")]
        public async Task<StockResponse> GetItem(string name)
        {
            var results = await _senderService.GetItem(name);

            return results;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStocks([FromBody] StockRequest stockRequest)
        {
            await _senderService.AddStocks(stockRequest);
            return Ok();
        }


        [HttpPatch]
        [Route("{name}")]
        public async Task<IActionResult> UpdateStock([FromBody] StockRequest stockRequest)
        {
            await _senderService.UpdateStock(stockRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("{name}")]
        public async Task<IActionResult> RemoveStock(string name)
        {
            await _senderService.RemoveStock(name);
            return Ok();

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Sender.Contracts;
using StockTrading.Sender.Services;
using StockTraiding.Receaver.Contracts;

namespace StockTrading.Sender.Controllers
{

   //[Route ("sender")]
    public class SenderController : Controller
    {
        private readonly ISenderService _SenderService;

        public SenderController(ISenderService senderSevice)
        {
            _SenderService = senderSevice;
        }

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
    }

    [HttpPost]
    //[Route ("addstock")]
    public async Task<IActionResult> AddStock(string Name, double price)
}
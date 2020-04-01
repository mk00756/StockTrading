using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Sender.Services;

namespace StockTrading.Sender.Controllers
{
   //[Route ("sender")]
    public class SenderController : Controller
    {
        private readonly ISenderService _SenderService;

        public SenderController (ISenderService senderSevice)
        {
            _SenderService = senderSevice;
        }
    }

    [HttpPost]
    //[Route ("addstock")]
    public async Task<IActionResult> AddStock(string Name, double price)
}
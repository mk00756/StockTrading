using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StockTrading.Receiver.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/Home")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
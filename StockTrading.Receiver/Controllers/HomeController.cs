<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver.MessageBroker;
using StockTrading.Receiver.Services;
>>>>>>> testbranch

namespace StockTrading.Receiver.Controllers {
    [Controller]
    public class HomeController : Controller
    {

        public readonly IStockService _stockServer;

        public HomeController(IStockService stockService)
        {
            _stockServer = stockService;


            // initialise each consumer
            AddConsumer add = new AddConsumer(_stockServer);
            DeleteConsumer delete = new DeleteConsumer(_stockServer);
            UpdateConsumer update = new UpdateConsumer(_stockServer);

            // initialise each thread
            Thread addThread = new Thread(new ThreadStart(add.ReceiveMessage));
            Thread deleteThread = new Thread(new ThreadStart(delete.ReceiveMessage));
            Thread updateThread = new Thread(new ThreadStart(update.ReceiveMessage));

            // start each receiving connection to the queue
            add.CreateConnection();
            delete.CreateConnection();
            update.CreateConnection();

            // start each thread
            addThread.Start();
            deleteThread.Start();
            updateThread.Start();
        }

        [Route("/Home")]
        public IActionResult Home() {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Sender.Contracts
{
    public class StockResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string LastUpdated { get; set; }

    }
}

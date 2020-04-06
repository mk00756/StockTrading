using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Receiver.Contracts {
    public class StockRespons {
        public string Name { get; set; }
        public double Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

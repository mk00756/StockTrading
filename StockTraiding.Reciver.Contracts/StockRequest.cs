using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrading.Receiver.Contracts {
    public class StockRequest {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StockTraiding.Receaver.Contracts {
    public class StockRespons {
        public string Name { get; set; }
        public int Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

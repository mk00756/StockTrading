using StockTrading.Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Methods {
    public interface IMapper {
        StockDB ToStockDBModel(StockDB stockDB);
        StockDB ToStockDBModel(string name, StockDB stockDB);
    }
}

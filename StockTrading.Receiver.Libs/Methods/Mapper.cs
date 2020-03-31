using StockTrading.Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Methods {
    public class Mapper : IMapper {
        public StockDB ToStockDBModel(StockDB stockDB) {
            return new StockDB {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = stockDB.LastUpdated
            };
        }
        public StockDB ToStockDBModel(string name, StockDB stockDB) {
            return new StockDB {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = DateTime.UtcNow.ToString()
            };
        }
    }
}

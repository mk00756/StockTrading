using StockTrading.Sender.Models;
using System;

namespace StockTrading.Sender.Mappers
{
    public class Mapper : IMapper
    {
        public StockDB ToStockDBModel(StockDB stockDB)
        {
            return new StockDB
            {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = stockDB.LastUpdated
            };
        }
        public StockDB ToStockDBModel(string name, StockDB stockDB)
        {
            return new StockDB
            {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = DateTime.UtcNow.ToString()
            };
        }



    }
}

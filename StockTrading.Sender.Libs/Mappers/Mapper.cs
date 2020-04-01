using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockTrading.Sender.Mappers
{
    public class Mapper : IMapper
    {

        public IEnumerable<StockResponse> ToStockContract(IEnumerable<StockDB> items)
        {
            return items.Select(ToStockContract);
        }
        public StockResponse ToStockContract(StockDB stockDB)
        {
            return new StockResponse
            {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = stockDB.LastUpdated
            };
        }

        public StockDB ToStockDBModel(StockRequest stockDB)
        {
            return new StockDB
            {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = DateTime.UtcNow.ToString()
            };
        }

        public StockDB ToStockDBModel(StockDB stockDB, StockRequest stockRequest)
        {
            return new StockDB
            {
                Name = stockDB.Name,
                Price = stockRequest.Price,
                LastUpdated = DateTime.UtcNow.ToString()
            };
        }




    }

}

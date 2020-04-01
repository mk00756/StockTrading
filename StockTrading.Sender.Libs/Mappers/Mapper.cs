﻿using StockTrading.Sender.Contracts;
using StockTrading.Sender.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockTrading.Sender.Mappers {
    public class Mapper : IMapper {

        public IEnumerable<StockResponse> ToStockContract(IEnumerable<StockDB> items)
        {
            return items.Select(ToStockDBContract);
        }
        public StockResponse ToStockDBContract(StockDB stockDB)
        {
            return new StockResponse
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

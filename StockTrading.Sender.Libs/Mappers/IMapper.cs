﻿using StockTrading.Sender.Contracts;
using StockTrading.Sender.Models;
using System.Collections.Generic;

namespace StockTrading.Sender.Mappers
{
    public interface IMapper
    {

        IEnumerable<StockResponse> ToStockContract(IEnumerable<StockDB> items);
        StockResponse ToStockDBContract(StockDB stockDB);
        StockDB ToStockDBModel(StockRequest stockDB);

        StockDB ToStockDBModel(string name, StockRequest stockDB);

    }
}

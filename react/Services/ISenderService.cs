﻿using StockTrading.Sender.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Services
{
    public interface ISenderService
    {
        Task<IEnumerable<StockResponse>> GetAllFromDatabase();
        Task<StockResponse> GetItem(string name);
        Task AddStocks(StockRequest stockRequest);
        Task UpdateStock(StockRequest stockRequest);
        Task RemoveStock(string name);
    }

}

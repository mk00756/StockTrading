using StockTrading.Receiver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Services {
    public interface IStockService {
        Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase();
        Task<StockRespons> GetStockByName(string stockName);
        Task AddStock(string StockName, StockRequest stock);
    }
}

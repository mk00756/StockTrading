using StockTraiding.Receaver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Services {
    public interface IStockService {
        Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase();
        Task<StockRespons> GetMovie(string stockName);
    }
}

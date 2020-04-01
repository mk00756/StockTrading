using StockTrading.Sender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Libs.Repositories
{
    public interface IStockTradingRepository
    {
        Task<IEnumerable<StockDB>> GetAllItems();
        Task<StockDB> GetItem(string name);
        Task AddStock(StockDB stockDB);
        Task DeleteStock(StockDB stockDB);
        Task UpdateStock(StockDB stockDB);

    }
}

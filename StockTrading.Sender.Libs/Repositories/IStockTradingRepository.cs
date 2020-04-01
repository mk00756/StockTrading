using StockTrading.Sender.Libs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Libs.Repositories
{
    public interface IStockTradingRepository
    {
        Task<IEnumerable<StockDB>> GetAllItems();      
        Task AddStock(StockDB stockDB);
        Task DeleteStock(StockDB stockDB);
        Task UpdateStock(StockDB stockDB);
    }
}

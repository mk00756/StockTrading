using Amazon.DynamoDBv2.DataModel;
using StockTrading.Sender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Libs.Repositories
{
    public class StockTradingRepository : IStockTradingRepository
    {
        private readonly DynamoDBContext _context;

        public async Task<IEnumerable<StockDB>> GetAllItems()
        {
            return await _context.ScanAsync<StockDB>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddStock(StockDB stockDB)
        {
            await _context.SaveAsync(stockDB);
        }

        public async Task DeleteStock(StockDB stockDB)
        {
            await _context.DeleteAsync(stockDB);
        }
        public async Task UpdateStock(StockDB stockDB)
        {
            await _context.SaveAsync(stockDB);
        }
    }
}

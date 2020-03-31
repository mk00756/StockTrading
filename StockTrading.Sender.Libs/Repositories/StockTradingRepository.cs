using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using StockTrading.Sender.Libs.MessageBroker;
using StockTrading.Sender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Sender.Libs.Repositories
{
    public class StockTradingRepository : IStockTradingRepository
    {
        private readonly DynamoDBContext _context;

        public StockTradingRepository (IAmazonDynamoDB amazonDynamoDB)
        {
            _context = new DynamoDBContext(amazonDynamoDB);
        }
        public async Task<IEnumerable<StockDB>> GetAllItems()
        {
            return await _context.ScanAsync<StockDB>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddStock(StockDB stockDB)
        {

            await _context.SaveAsync(stockDB);

            SendMQ sendMQ = new SendMQ();
            sendMQ.SendStock(stockDB);
            
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

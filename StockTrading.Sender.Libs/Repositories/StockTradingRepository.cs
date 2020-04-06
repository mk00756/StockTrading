﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using StockTrading.Sender.Libs.MessageBroker;
using StockTrading.Sender.Libs.Models;
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

        public async Task<StockDB> GetItem(string name)
        {
            return await _context.LoadAsync<StockDB>(name);
        }
        public async Task AddStock(StockDB stockDB)
        {

            await _context.SaveAsync(stockDB);

            RabbitMQClient client = new RabbitMQClient("Add_Queue", "stock.add");
            client.SendMethod(stockDB, "stock.add");
            
        }
        public async Task DeleteStock(StockDB stockDB)
        {
            await _context.DeleteAsync(stockDB);

            RabbitMQClient client = new RabbitMQClient("Delete_Queue", "stock.delete");
            client.SendMethod(stockDB, "stock.delete");
        }
        public async Task UpdateStock(StockDB stockDB)
        {
            await _context.SaveAsync(stockDB);

            RabbitMQClient client = new RabbitMQClient("Patch_Queue", "stock.patch");
            client.SendMethod(stockDB, "stock.patch");
        }
    }
}

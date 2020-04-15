using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Repository {
    public class StockRepository : IStockRepository
    {
        private const string TableName = "StockTraderReceaver";
        private readonly Table _table;
        public StockRepository(IAmazonDynamoDB dynamoDbCleint)
        {
            _table = Table.LoadTable(dynamoDbCleint, TableName);
        }
        public async Task<IEnumerable<Document>> GetAllItems()
        {
            var config = new ScanOperationConfig();
            return await _table.Scan(config).GetRemainingAsync();
        }
        public async Task<Document> GetStockByName(string stockName)
        {
            return await _table.GetItemAsync(stockName);
        }
        public async Task AddStock(Document documentModel)
        {
            await _table.PutItemAsync(documentModel);
        }
        public async Task DeleteStock(Document documentModel)
        {
            await _table.DeleteItemAsync(documentModel);
        }

        public async Task UpdateStock(Document documentModel)
        {
            await _table.UpdateItemAsync(documentModel);
        }
    }
}
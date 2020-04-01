using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Repository {
    public class StockRepository : IStockRepository {
        private const string TableName = "StockTracking";
        private readonly Table _table;
        public StockRepository(IAmazonDynamoDB dynamoDbCleint) => _table = Table.LoadTable(dynamoDbCleint, TableName);
        public async Task<IEnumerable<Document>> GetAllItems() {
            var config = new ScanOperationConfig();
            return await _table.Scan(config).GetRemainingAsync();
        }
    }
}

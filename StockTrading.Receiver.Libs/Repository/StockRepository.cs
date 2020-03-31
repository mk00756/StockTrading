using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Repository {
    public class StockRepository : IStockRepository {
        private const string TableName = "MovieRank";
        private readonly Table _table;

        public StockRepository(IAmazonDynamoDB dynamoDbCleint) {
            _table = Table.LoadTable(dynamoDbCleint, TableName);
        }
    }
}

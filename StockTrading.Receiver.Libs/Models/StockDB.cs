using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace StockTrading.Receiver.Models {
    [DynamoDBTable("StockTracking")]
    public class StockDB {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public int Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

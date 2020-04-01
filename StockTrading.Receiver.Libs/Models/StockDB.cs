using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace StockTrading.Receiver.Models {
    [DynamoDBTable("StockTracking")]
    [Serializable]
    public class StockDB {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public string Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

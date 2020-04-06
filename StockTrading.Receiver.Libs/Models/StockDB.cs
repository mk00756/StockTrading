using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace StockTrading.Receiver.Models {
    [DynamoDBTable("StockTraderReceaver")]
    [Serializable]
    public class StockDB {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public double Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

using Amazon.DynamoDBv2.DataModel;

namespace StockTrading.Sender.Models
{
    [DynamoDBTable("StockTracking")]

    public class StockDB
    {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public int Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

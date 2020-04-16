using Amazon.DynamoDBv2.DataModel;

namespace StockTrading.Sender.Libs.Models
{
    [DynamoDBTable("StockTracking")]

    public class StockDB
    {
        [DynamoDBHashKey]
        public string Name { get; set; }
        public double Price { get; set; }
        public string LastUpdated { get; set; }
    }
}

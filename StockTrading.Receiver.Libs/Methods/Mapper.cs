using Amazon.DynamoDBv2.DocumentModel;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Methods {
    public class Mapper : IMapper {
        public IEnumerable<StockRespons> ToStockContract(IEnumerable<Document> Items) {
            return Items.Select(ToStockContract);
        }
        public StockRespons ToStockContract(Document items) {
            return new StockRespons {
                Name = items["Name"],
                Price = items["Price"].AsDouble(),
                LastUpdated = items["LastUpdated"]
            };
        }
        public Document ToDocumentMode(StockRespons stock) {
            return new Document {
                ["Name"] = stock.Name,
                ["Price"] = stock.Price,
                ["LastUpdated"] = DateTime.UtcNow.ToString()
            };
        }
    }
}

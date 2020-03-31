using Amazon.DynamoDBv2.DocumentModel;
using StockTrading.Receiver.Models;
using StockTraiding.Receaver.Contracts;
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
                Price = Convert.ToInt32(items["Price"])
            };
        }

    }
}

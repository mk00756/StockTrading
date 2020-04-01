using Amazon.DynamoDBv2.DocumentModel;
using StockTrading.Receiver.Models;
using StockTraiding.Receaver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Methods {
    public interface IMapper {
        IEnumerable<StockRespons> ToStockContract(IEnumerable<Document> Items);
        StockRespons ToStockContract(Document items);
    }
}

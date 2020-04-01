using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver {
    public interface IStockRepository {
        Task<IEnumerable<Document>> GetAllItems();
        Task<Document> GetStockByName(string stockName);
        Task AddStock(Document documentModel);
    }
}

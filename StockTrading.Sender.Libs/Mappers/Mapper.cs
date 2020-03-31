using StockTrading.Sender.Models;

namespace StockTrading.Sender.Mappers
{
    public class Mapper : IMapper
    {
        public StockDB ToStockDBModel(StockDB stockDB)
        {
            return new StockDB
            {
                Name = stockDB.Name,
                Price = stockDB.Price,
                LastUpdated = stockDB.LastUpdated
            };
        }
    }
}

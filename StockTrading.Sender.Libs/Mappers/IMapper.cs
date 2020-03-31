using StockTrading.Sender.Models;

namespace StockTrading.Sender.Mappers
{
    public interface IMapper
    {
        StockDB ToStockDBModel(StockDB stockDB);
        StockDB ToStockDBModel(string name, StockDB stockDB);
    }
}

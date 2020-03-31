using StockTrading.Receiver.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Services {
    public class StockService : IStockService {
        private readonly StockRepository _stockRepository;
        private readonly IMapper _map;
    }
}

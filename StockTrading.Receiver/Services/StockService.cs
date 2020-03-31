using StockTrading.Sender.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Services {
    public class StockService : IStockService {
        private readonly IStockRepository _stockRepository;
        public readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper) {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

    }
}

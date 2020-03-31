using StockTrading.Receiver.Methods;
using StockTraiding.Receaver.Contracts;
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

        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var response = await _stockRepository.GetAllItems();
            return _mapper.ToStockContract(response);
        }
    }
}

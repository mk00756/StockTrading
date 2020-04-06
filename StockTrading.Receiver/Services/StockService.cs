using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Methods;
using System;
using System.Collections.Generic;
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
        public async Task<StockRespons> GetStockByName(string stockName) {
            var response = await _stockRepository.GetStockByName(stockName);
            return _mapper.ToStockContract(response);
        }
        public async Task AddStock(StockRespons stock) {
            var stockIn = _mapper.ToDocumentMode(stock);
            await _stockRepository.AddStock(stockIn);
        }
    }
}

using StockTrading.Sender.Libs.Repositories;
using StockTrading.Sender.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTrading.Sender.Contracts;

namespace StockTrading.Sender.Services
{
    public class SenderService : ISenderService
    {
        private readonly IStockTradingRepository _stockTradingRepository;
        private readonly IMapper _mapper;
        public SenderService(IStockTradingRepository stockTradingRepository, IMapper mapper)
        {
            _stockTradingRepository = stockTradingRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StockResponse>> GetAllFromDatabase()
        {
            var response = await _stockTradingRepository.GetAllItems();
            return _mapper.ToStockContract(response);
        }
        public async Task<StockResponse> GetItem(string name)
        {
            var response = await _stockTradingRepository.GetItem(name);
            return _mapper.ToStockContract(response);
        }

        public async Task AddStocks(StockRequest stockRequest)
        {
            var response = _mapper.ToStockDBModel(stockRequest);

            await _stockTradingRepository.AddStock(response);

        }

        public async Task UpdateStock(StockRequest stockRequest)
        {
            var response = await _stockTradingRepository.GetItem(stockRequest.Name);
            var result = _mapper.ToStockDBModel(response, stockRequest);

            await _stockTradingRepository.UpdateStock(result);

        }

        public async Task RemoveStock(string name)
        {
            var response = await _stockTradingRepository.GetItem(name);
            await _stockTradingRepository.DeleteStock(response);
        }

    }
}

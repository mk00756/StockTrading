using StockTrading.Sender.Libs.Repositories;
using StockTrading.Sender.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockTrading.Sender.Contracts;

namespace StockTrading.Sender.Services
{
    public class SenderService: ISenderService
    {
        private readonly IStockTradingRepository _stockTradingRepository;
        private readonly IMapper _mapper;
        public SenderService(IStockTradingRepository stockTradingRepository, IMapper mapper)
        {
            _stockTradingRepository = stockTradingRepository;
            _mapper = mapper;
        }
        public async Task <IEnumerable<StockResponse>> GetAllFromDatabase()
        {
            var response = await _stockTradingRepository.GetAllItems();
            return _mapper.ToStockContract(response);
        }
    }
}

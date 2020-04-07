using Microsoft.AspNetCore.Mvc;
using StockTrading.Receiver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrading.Receiver.Consumers
{
    public interface IConsumer
    {
        void CreateConnection();
        void Close();
        void ReceiveMessage();
        void ConsumeMessage([FromBody] StockRespons stock);

    }
}

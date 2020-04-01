using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using StockTrading.Receiver.Models;
using StockTrading.Receiver.Services;
using StockTraiding.Receaver.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace StockTrading.Receiver.Controllers {

    [Route("Reciver")]
    [ApiController]
    public class StockController : ControllerBase {

        private IModel _model;
        private IConnection _conection;
        private ConnectionFactory _factory;

        private const string QueueName = "QueName";

        public readonly IStockService _stockServer;
        public StockController(IStockService stockService) {
            _stockServer = stockService;
            ReceaveMesages();
        }

        private void ReceaveMesages() {
            var consumer = new QueueingBasicConsumer(_model);
            var msgCount = GetMessageCount(_model, QueueName);

            _model.BasicConsume(QueueName, true, consumer);

            var count = 0;

            while (count < msgCount) {
                var mesage = (StockDB)consumer.Queue.Dequeue().Body.DeSerialize(typeof(StockDB));
                count++;
            }
        }

        private static uint GetMessageCount(IModel chanel, string queueName) {
            var result = chanel.QueueDeclare(queueName, true, false, false, null);
            return result.MessageCount;
        }

        private object DesSerialize(this byte[] arrBytes, Type type) {
            var jason = Encoding.Default.GetString(arrBytes);
            return JsonConverter.DeserilizeObject(jason,
                                                  type);
        }

        public string DesrializeText(this byte[] arrBytes) {
            return Encoding.Default.GetString(arrBytes);
        }

        [HttpGet]
        public async Task<IEnumerable<StockRespons>> GetAllItemsFromDatabase() {
            var result = await _stockServer.GetAllItemsFromDatabase();
            return result;
        }
        //[HttpGet]
        //[Route("{StockName}")]
        //public async Task<StockRespons> GetItemsFromDatabaseByName(string StockName) {
        //    var result = await _stockServer.GetStockByName(StockName);
        //    return result;
        //}
    }
}
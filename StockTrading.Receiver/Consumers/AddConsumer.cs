using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Models;
using StockTrading.Receiver.Services;
using System.Text;
using System.Threading.Tasks;

namespace StockTrading.Receiver.MessageBroker
{
    public class AddConsumer
    {
        private readonly IStockService _stockServer;

        private static ConnectionFactory _factory;
        private static IConnection _connection;


        private const string ExchangeName = "Topic_Exchange";
        private const string AllQueueName = "Add_Queue";


        public AddConsumer(IStockService stockService)
        {
            _stockServer = stockService;
        }
        public void CreateConnection()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
        }

        public void Close()
        {
            _connection.Close();
        }

        public async Task ReceiveMessage()
        {
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "topic");
                    channel.QueueDeclare(AllQueueName, true, false, false, null);
                    channel.QueueBind(AllQueueName, ExchangeName, "stock.add");


                    channel.BasicQos(0, 10, false);
                    Subscription subscription = new Subscription(channel, AllQueueName, false);


                    BasicDeliverEventArgs deliveryArguments = subscription.Next();

                    var body = deliveryArguments.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var stock = JsonConvert.DeserializeObject<StockRespons>(message);
                    //returnMessage = stock.ToString();

                    subscription.Ack(deliveryArguments);

                    await ConsumeMessage(stock);
                }

            }
        }

        public async Task ConsumeMessage([FromBody] StockRespons stock)
        {
            await _stockServer.AddStock(stock);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using StockTrading.Receiver.Consumers;
using StockTrading.Receiver.Contracts;
using StockTrading.Receiver.Models;
using StockTrading.Receiver.Services;
using StockTrading.Receiver.Twillio;
using System.Text;
using System.Threading.Tasks;

namespace StockTrading.Receiver.MessageBroker
{
    public class AddConsumer: IConsumer
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

        public void ReceiveMessage()
        {
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    // create and declare queue
                    channel.ExchangeDeclare(ExchangeName, "topic");
                    channel.QueueDeclare(AllQueueName, true, false, false, null);
                    channel.QueueBind(AllQueueName, ExchangeName, "stock.add");
                    BasicGetResult status = channel.BasicGet(AllQueueName, false);
                    
                    //channel.BasicQos(0, 10, false);
                    Subscription subscription = new Subscription(channel, AllQueueName,true);

                    //read from queue until no messages left

                    while (true)
                    {
                        BasicDeliverEventArgs deliveryArguments = subscription.Next();

                        var body = deliveryArguments.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var stock = JsonConvert.DeserializeObject<StockRespons>(message);

                        subscription.Ack(deliveryArguments);

                        // perform operation
                        ConsumeMessage(stock);

                    }
                }

            }
        }

        public void ConsumeMessage([FromBody] StockRespons stock)
        {
             _stockServer.AddStock(stock);
            SendSMS send = new SendSMS();
            send.InitializeSMS();
            send.sendSMS("ADDED", stock.Name.ToString());
        }
    }
}
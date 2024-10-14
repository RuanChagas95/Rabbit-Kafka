using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace RabbitMQ.Repositories
{

    public class RabbitMQRepository : IRabbitMQRepository
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string queueName = "myQueue";

        public RabbitMQRepository()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }

        public List<string> GetMessages()
        {
            var messages = new List<string>();
            int counter = 0;
            while (true && counter < 10)
            {
                counter++;
                var result = _channel.BasicGet(queue: queueName, autoAck: true);
                if (result == null)
                {
                    break;
                }

                var body = result.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messages.Add(message);
            }

            return messages;
        }
    }

}
namespace RabbitMQ.Repositories
{
    public interface IRabbitMQRepository
    {
        public void SendMessage(string message);
        public List<string> GetMessages();

    }
}
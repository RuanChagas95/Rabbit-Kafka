using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Repositories;

namespace RabbitMQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQRepository _rabbitMQService;

        public RabbitMQController(IRabbitMQRepository rabbitMQRepository)
        {
            _rabbitMQService = rabbitMQRepository;
        }

        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] string message)
        {
            _rabbitMQService.SendMessage(message);
            return Ok("Message sent to RabbitMQ");
        }

        [HttpGet("receive")]
        public IActionResult ReceiveMessage()
        {

            return Ok(new { message = _rabbitMQService.GetMessages() });
        }
    }
}
namespace NetCoreApiPoc.Controllers
{
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using RabbitMQ.Client;

    [Route("hello-world")]
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public string Get(string message)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
                const string QName = "hello";

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: QName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        channel.BasicPublish(exchange: "",
                            routingKey: QName,
                            basicProperties: null,
                            body: Encoding.UTF8.GetBytes(message));

                        return "Sent " + message;
                    }
                }

        }
    }
}

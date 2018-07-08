namespace RabbitConsumerPoc
{
    using System;
    using System.Text;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    class Program
    {
        public static void Main()
        {
                var factory = new ConnectionFactory
                {
                HostName = "rabbitmq"
                };

                using (var connection = factory.CreateConnection())
                {
                    connection.ConnectionShutdown += Connection_ConnectionShutdown;

                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "hello",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
                        
                        var consumer = new EventingBasicConsumer(channel);

                        consumer.Received += ProcessReceived;

                        channel.BasicConsume(queue: "hello",
                                             autoAck: true,
                                             consumer: consumer);

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                }
        }

        private static void ProcessReceived(object sender, BasicDeliverEventArgs e)
        {
            var content = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(content);
        }

        private static void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("Connection was ShutDown because: " + e.Cause);
        }
    }
}

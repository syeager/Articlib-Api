//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;

//var factory = new ConnectionFactory() { HostName = "articlib-rabbitmq" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();
//channel.QueueDeclare(
//    queue: "articles-created",
//    durable: true,
//    exclusive: false,
//    autoDelete: false);

//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, args) =>
//{
//    var body = args.Body.ToArray();
//    var message = new Guid(body);
//    Console.WriteLine($" [x] Received {message}");
//};

//channel.BasicConsume("articles-created", true, consumer);
//Console.WriteLine(" Press [enter] to exit.");
//Console.ReadLine();

using Articlib.Notifications.Api.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMessaging(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

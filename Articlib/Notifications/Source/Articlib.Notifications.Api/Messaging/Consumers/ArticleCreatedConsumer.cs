using LittleByte.Messaging;

namespace Articlib.Notifications.Api.Messaging
{
    public class ArticleCreatedConsumer : Consumer<Guid>
    {
        public override string QueueName => "articles-created";

        protected override Task ProcessMessageInternalAsync(Guid message)
        {
            Console.WriteLine($"Received article created: {message}");
            return Task.CompletedTask;
        }
    }
}

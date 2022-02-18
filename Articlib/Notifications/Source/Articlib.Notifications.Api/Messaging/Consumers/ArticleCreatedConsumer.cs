using Articlib.Notifications.Infra.ArticleCreated;
using LittleByte.Messaging;

namespace Articlib.Notifications.Api.Messaging
{
    public class ArticleCreatedConsumer : Consumer<Guid>
    {
        // TODO: I don't like this but I'm not sure how I want to separate the layers yet.
        private class Notification : IArticleCreated
        {
            public Guid UserId { get; } = Guid.NewGuid();
            public Guid ArticleId { get; } = Guid.NewGuid();
        }

        private readonly IAddArticleCreatedCommand addArticleCreatedCommand;

        public override string QueueName => "articles-created";

        public ArticleCreatedConsumer(IAddArticleCreatedCommand addArticleCreatedCommand)
        {
            this.addArticleCreatedCommand = addArticleCreatedCommand;
        }

        // TODO: We will eventually be sending serialized messages to the MQ (e.g., articles sent via protobuf).
        protected override Task ProcessMessageInternalAsync(Guid message)
        {
            Console.WriteLine($"Received article created: {message}");
            addArticleCreatedCommand.AddRange(new[] {new Notification()});
            return Task.CompletedTask;
        }
    }
}

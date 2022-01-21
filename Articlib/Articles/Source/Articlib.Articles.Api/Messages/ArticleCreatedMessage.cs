using LittleByte.Messaging;

namespace Articlib.Articles.Api.Messages;

public sealed class ArticleCreatedMessage : Message
{
    public ArticleCreatedMessage(Guid body)
        : base(body) { }

    public override string QueueName => "articles-created";
}

using LittleByte.Messaging;

namespace Articlib.Core.Api.Articles;

public sealed class ArticleCreatedMessage : Message
{
    public ArticleCreatedMessage(Guid body)
        : base(body)
    {
    }

    public override string QueueName => "articles-created";
}
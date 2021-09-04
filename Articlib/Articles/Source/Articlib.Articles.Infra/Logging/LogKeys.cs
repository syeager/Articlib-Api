using LittleByte.Logging;

namespace Articlib.Articles.Infra;

public static partial class LogKeys
{
    public const string Article = nameof(Article);
    public const string Id = nameof(Id);

    public static class Articles
    {
        public static readonly string Id = Keys.New(Article, LogKeys.Id);
    }
}

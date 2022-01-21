using System.Diagnostics.CodeAnalysis;

namespace Articlib.Core.Infra;

[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public static class LogKeys
{
    private const string Article = nameof(Article);
    private const string Id = nameof(Id);

    public static class Articles
    {
        public static readonly string Id = Keys.New(Article, LogKeys.Id);
    }
}

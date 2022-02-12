namespace Articlib.Core.Domain.Articles.Exceptions;

public sealed class ArticleVoteOverflowException : Exception
{
    public Article Article { get; }

    public ArticleVoteOverflowException(Article article)
    : base("Article vote count is outside the viable range.")
    {
        Article = article;
    }
}

using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles.Models;
using AutoMapper;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Articles.Mappings;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal sealed class ArticleConverter : ITypeConverter<ArticleDao, Valid<Article>>
{
    private readonly IModelValidator<Article> validator;

    public ArticleConverter(IModelValidator<Article> validator)
    {
        this.validator = validator;
    }

    public Valid<Article> Convert(ArticleDao source, Valid<Article> destination, ResolutionContext context)
    {
        var articleTags = source.ArticleTags.Select(context.Mapper.Map<ArticleTag>).ToArray();

        var article = Article.Create(
            validator,
            source.Id,
            new Uri(source.Url),
            source.VoteCount,
            articleTags);
        return article;
    }
}

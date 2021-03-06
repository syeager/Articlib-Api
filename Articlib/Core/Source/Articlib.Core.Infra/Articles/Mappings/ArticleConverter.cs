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
        var article = Article.Create(
            validator,
            source.Id,
            new Uri(source.Url),
            source.VoteCount,
            source.PostedCount,
            source.LastPostedDate);
        return article;
    }
}

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class ValidConverter<TSource, TDestination> : ITypeConverter<Valid<TSource>, TDestination>
{
    public TDestination Convert(Valid<TSource> source, TDestination destination, ResolutionContext context) => context.Mapper.Map<TDestination>(source.GetModelOrThrow());
}

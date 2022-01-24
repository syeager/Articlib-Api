﻿using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Votes.Services;
using LittleByte.Validation;

namespace Articlib.Core.Api.Articles;

internal static class ArticleConfiguration
{
    public static IServiceCollection AddArticles(this IServiceCollection @this)
    {
        return @this
            .AddTransient<IAddVote, AddVote>()
            .AddTransient<IModelValidator<Article>, ArticleValidator>()
            .AddTransient<IArticleCreateService, ArticleCreateService>();
    }
}
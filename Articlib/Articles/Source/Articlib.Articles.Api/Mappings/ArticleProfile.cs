using Articlib.Core.Domain;
using AutoMapper;

namespace Articlib.Articles.Api;

internal class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>();
    }
}

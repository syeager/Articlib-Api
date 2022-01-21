using Articlib.Articles.Domain.Articles;
using AutoMapper;

namespace Articlib.Articles.Api;

internal class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>();
    }
}

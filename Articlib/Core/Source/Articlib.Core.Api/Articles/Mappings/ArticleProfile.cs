using Articlib.Core.Domain.Articles;
using AutoMapper;

namespace Articlib.Core.Api.Articles;

internal class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ArticleDto>();
    }
}

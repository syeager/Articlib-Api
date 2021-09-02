
using AutoMapper;

namespace Articlib.Articles.Api;

internal class ArticleProfile : Profile
{
    public ArticleProfile(IArticleReadRepo articleRepo)
    {
        CreateMap<Article, ArticleDto>().ForMember(a => a.Id, config => config.MapFrom((domain, dto) => articleRepo.GetId(domain)));
    }
}

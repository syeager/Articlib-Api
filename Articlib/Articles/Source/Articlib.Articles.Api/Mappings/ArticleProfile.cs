using AutoMapper;

namespace Articlib.Articles.Api;

internal class ArticleProfile : Profile
{
    public ArticleProfile(IEntityIdReadCache entityIdCache)
    {
        CreateMap<Article, ArticleDto>().ForMember(
            a => a.Id,
            config => config.MapFrom((domain, dto) => entityIdCache.Get(domain.Url.AbsoluteUri)));
    }
}

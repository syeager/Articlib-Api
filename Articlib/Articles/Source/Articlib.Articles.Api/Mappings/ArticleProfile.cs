using AutoMapper;
using LittleByte.Infra;

namespace Articlib.Articles.Api;

internal class ArticleProfile : Profile
{
    public ArticleProfile(IEntityIdReadCache entityIdCache)
    {
        CreateMap<Article, ArticleDto>().ForMember(
            a => a.Id,
            config => config.MapFrom((domain, _) => entityIdCache.Get(domain.Url.AbsoluteUri)));
    }
}

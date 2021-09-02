using AutoMapper;

namespace Articlib.Articles.Infra;

internal class ArticleProfile : Profile
{
    public ArticleProfile(IArticleReadRepo articleRepo)
    {
        CreateMap<Uri, string>().ConvertUsing(uri => uri.AbsoluteUri);
        CreateMap<string, Uri>().ConvertUsing(s => new Uri(s));

        CreateMap<Article, ArticleDao>()
            .ForMember(a => a.Id, m => m.MapFrom((domain, dto) => articleRepo.GetId(domain)));

        CreateMap<ArticleDao, Article>();
    }
}

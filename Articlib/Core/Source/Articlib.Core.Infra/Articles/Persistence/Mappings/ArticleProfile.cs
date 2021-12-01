using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles.Daos;
using AutoMapper;

namespace Articlib.Core.Infra.Articles.Mappings;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Uri, string>().ConvertUsing(uri => uri.AbsoluteUri);
        CreateMap<string, Uri>().ConvertUsing(s => new Uri(s));

        CreateMap<Article, ArticleDao>();
        CreateMap<ArticleDao, Article>();
    }
}

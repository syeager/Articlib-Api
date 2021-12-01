using Articlib.Core.Domain.Articles;
using AutoMapper;

namespace Articlib.Core.Infra.Articles;

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

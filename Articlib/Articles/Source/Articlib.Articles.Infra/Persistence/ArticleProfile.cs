using Articlib.Core.Domain;
using AutoMapper;

namespace Articlib.Core.Infra;

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

using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Votes.Models;
using AutoMapper;

namespace Articlib.Core.Infra.Articles.Mappings;

public sealed class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Uri, string>().ConvertUsing(uri => uri.AbsoluteUri);
        CreateMap<string, Uri>().ConvertUsing(s => new Uri(s));

        CreateMap<Article, ArticleDao>();
        CreateMap<ArticleDao, Article>().DisableCtorValidation().ConvertUsing<ArticleConverter>();

        CreateMap<VoteDao, Vote>();
        CreateMap<Vote, VoteDao>();
    }
}

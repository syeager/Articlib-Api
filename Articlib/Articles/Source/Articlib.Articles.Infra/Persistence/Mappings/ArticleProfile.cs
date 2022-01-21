using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Votes.Models;
using Articlib.Articles.Infra.Persistence.Daos;
using AutoMapper;

namespace Articlib.Articles.Infra.Persistence;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Uri, string>().ConvertUsing(uri => uri.AbsoluteUri);
        CreateMap<string, Uri>().ConvertUsing(s => new Uri(s));

        CreateMap<Article, ArticleDao>();
        CreateMap<VoteDao, Vote>();
        CreateMap<Vote, VoteDao>();
    }
}

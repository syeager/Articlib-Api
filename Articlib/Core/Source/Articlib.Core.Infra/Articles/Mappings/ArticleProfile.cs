using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Votes.Models;
using AutoMapper;
using LittleByte.Extensions.AutoMapper;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Articles.Mappings;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Uri, string>().ConvertUsing(uri => uri.AbsoluteUri);
        CreateMap<string, Uri>().ConvertUsing(s => new Uri(s));

        CreateMap<Valid<Article>, ArticleDao>();
        CreateMap<ArticleDao, Valid<Article>>().DisableCtorValidation().ConvertUsing<ArticleConverter>();

        this.CreateBiDirectionMap<VoteDao, Vote>();
        this.CreateBiDirectionMap<ArticlePostDao, ArticlePost>();
    }
}

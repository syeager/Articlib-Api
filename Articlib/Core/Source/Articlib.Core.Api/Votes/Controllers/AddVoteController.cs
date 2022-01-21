using System.Net;
using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Votes.Requests;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Services;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Extensions.AspNet.Unleash;
using LittleByte.Infra.Commands;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Votes.Controllers;

public sealed class AddVoteController : VoteController
{
    private readonly IMapper mapper;
    private readonly IAddVote addVote;

    private readonly ISaveContextCommand saveContextCommand;

    public AddVoteController(
        IMapper mapper,
        IAddVote addVote,
        IFindByIdQuery<User> findUser,
        IFindByIdQuery<Article> findArticle,
        ISaveContextCommand saveContextCommand)
        : base(findUser, findArticle)
    {
        this.mapper = mapper;
        this.addVote = addVote;
        this.saveContextCommand = saveContextCommand;
    }

    [HttpPut("vote-add")]
    [FeatureGate("vote-article")]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> AddVote(VoteRequest request)
    {
        var (user, article) = await GetUserAndArticle(request);
        await addVote.AddAsync(article, user);

        await saveContextCommand.CommitChangesAsync();

        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
}

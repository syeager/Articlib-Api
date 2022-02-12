using System.Net;
using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Votes.Requests;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Services;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Commands;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Votes.Controllers;

public sealed class RemoveVoteController : VoteController
{
    private readonly IMapper mapper;
    private readonly IRemoveVoteService removeVoteService;
    private readonly ISaveContextCommand saveContextCommand;

    public RemoveVoteController(
        IMapper mapper,
        IRemoveVoteService removeVoteService,
        IFindByIdQuery<User> findUser,
        IFindByIdQuery<Article> findArticle,
        ISaveContextCommand saveContextCommand)
        : base(findUser, findArticle)
    {
        this.mapper = mapper;
        this.removeVoteService = removeVoteService;
        this.saveContextCommand = saveContextCommand;
    }

    [HttpPut("vote-remove")]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> RemoveVote(VoteRequest request)
    {
        var (user, article) = await GetUserAndArticle(request);
        await removeVoteService.RemoveAsync(article, user);

        await saveContextCommand.CommitChangesAsync();

        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
}

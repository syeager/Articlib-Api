using System.Net;
using Articlib.Articles.Api.Requests;
using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Users;
using Articlib.Articles.Domain.Votes.Services;
using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

public sealed class ToggleVoteController : ArticleController
{
    private readonly IMapper mapper;
    private readonly IAddVote addVote;
    private readonly IFindByIdQuery<User> findUser;
    private readonly IFindByIdQuery<Article> findArticle;

    public ToggleVoteController(IMapper mapper, IAddVote addVote, IFindByIdQuery<User> findUser, IFindByIdQuery<Article> findArticle)
    {
        this.mapper = mapper;
        this.addVote = addVote;
        this.findUser = findUser;
        this.findArticle = findArticle;
    }

    [HttpPut("vote-add")]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> AddVote(VoteRequest request)
    {
        var (user, article) = await GetUserAndArticle(request);
        await addVote.AddAsync(article, user);

        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }

    [HttpPut("vote-remove")]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> RemoveVote(VoteRequest request)
    {
        var (user, article) = await GetUserAndArticle(request);
        await addVote.AddAsync(article, user);

        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
    
    private async Task<(User user, Article article)> GetUserAndArticle(VoteRequest request)
    {
        var user = await findUser.FindAsync(request.UserId);
        if(user is null)
        {
            throw new NotFoundException(typeof(User), request.UserId);
        }

        var article = await findArticle.FindAsync(request.ArticleId);
        if(article is null)
        {
            throw new NotFoundException(typeof(Article), request.ArticleId);
        }

        return (user, article);
    }
}

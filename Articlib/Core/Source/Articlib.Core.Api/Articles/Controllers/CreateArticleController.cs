using System.Net;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Articles;

//[Authorize]
public sealed class CreateArticleController : ArticleController
{
    private readonly IArticleCreateService articleCreateService;
    private readonly IArticleReadRepo articleRepo;
    private readonly IMapper mapper;
    private readonly MessagePublisher messagePublisher;

    public CreateArticleController(IArticleReadRepo articleRepo, IMapper mapper,
        IArticleCreateService articleCreateService, MessagePublisher messagePublisher)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
        this.articleCreateService = articleCreateService;
        this.messagePublisher = messagePublisher;
    }

    [HttpPost("create")]
    [ResponseType(HttpStatusCode.BadRequest)]
    [ResponseType(HttpStatusCode.Created, typeof(ArticleDto))]
    public async Task<ApiResponse<ArticleDto>> Create(ArticleCreateRequest request)
    {
        var validArticle = articleCreateService.Create(new Uri(request.Url), request.PosterId);
        var article = validArticle.GetModelOrThrow();
        await articleRepo.SaveChangesAsync();
        var dto = mapper.Map<ArticleDto>(article);

        var message = new ArticleCreatedMessage(dto.Id);
        messagePublisher.Publish(message);

        return new CreatedResponse<ArticleDto>(dto);
    }
}
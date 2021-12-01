using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
[Authorize]
public class ArticleAuthorizedController : Controller
{
    private readonly IArticleWriteRepo articleRepo;
    private readonly IMapper mapper;
    private readonly IArticleValidator articleValidator;

    public ArticleAuthorizedController(IArticleWriteRepo articleRepo, IMapper mapper, IArticleValidator articleValidator)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
        this.articleValidator = articleValidator;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ArticleDto>> Create(string url)
    {
        var uri = new Uri(url);
        var validArticle = Article.Create(articleValidator, uri);
        var article = articleRepo.Add(validArticle);
        await articleRepo.SaveChangesAsync();
        var dto = mapper.Map<ArticleDto>(article);
        return Ok(dto);
    }
}

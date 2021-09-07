using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
public class ArticleAuthorizedController : Controller
{
    private readonly IArticleWriteRepo articleRepo;
    private readonly IMapper mapper;

    public ArticleAuthorizedController(IArticleWriteRepo articleRepo, IMapper mapper)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ArticleDto>> Create(string url)
    {
        var uri = new Uri(url);
        var validArticle = Article.Create(uri);
        var article = await articleRepo.CreateAsync(validArticle);
        var dto = mapper.Map<ArticleDto>(article);
        return Ok(dto);
    }
}

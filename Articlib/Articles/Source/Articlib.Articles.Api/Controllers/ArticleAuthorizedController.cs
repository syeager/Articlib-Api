using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
public class ArticleAuthorizedController : Controller
{
    private readonly IArticleWriteRepo articleRepo;

    public ArticleAuthorizedController(IArticleWriteRepo articleRepo)
    {
        this.articleRepo = articleRepo;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ArticleDto>> Create(string url)
    {
        var uri = new Uri(url);
        var validArticle = Article.Create(uri);
        var article = await articleRepo.CreateAsync(validArticle);
        var dto = ArticleDto.ToDto(article, articleRepo);
        return Ok(dto);
    }
}

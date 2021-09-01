
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
public class ArticleController : Controller
{
    private readonly IArticleReadRepo articleRepo;

    public ArticleController(IArticleWriteRepo articleRepo)
    {
        this.articleRepo = articleRepo;
    }

    [HttpGet]
    public async Task<ActionResult<ArticleDto>> Get(Guid id)
    {
        var article = await articleRepo.GetByIdAsync(id);
        var dto = ArticleDto.ToDto(article, articleRepo);
        return Ok(dto);
    }
}

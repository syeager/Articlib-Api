
using Articlib.Articles.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
public class ArticleAuthorizedController : Controller
{
    [HttpPost("create")]
    public ActionResult<ArticleDto> Create(string url)
    {
        var uri = new Uri(url);
        var article = Article.Create(uri).GetModelOrThrow();
        var dto = ArticleDto.ToDto(article);
        return Ok(dto);
    }
}

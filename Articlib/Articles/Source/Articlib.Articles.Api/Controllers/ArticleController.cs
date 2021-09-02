
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[ApiController]
public class ArticleController : Controller
{
    private readonly IArticleReadRepo articleRepo;
    private readonly IMapper mapper;

    public ArticleController(IArticleWriteRepo articleRepo, IMapper mapper)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ArticleDto>> Get(Guid id)
    {
        var article = await articleRepo.GetByIdAsync(id);
        var dto = mapper.Map<ArticleDto>(article);
        return Ok(dto);
    }
}

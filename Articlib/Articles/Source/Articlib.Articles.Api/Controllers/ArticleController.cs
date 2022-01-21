using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Articlib.Articles.Api;

[Route("articles", Name = "Articles")]
[OpenApiTag("Articles")]
[ApiController]
public abstract class ArticleController : Controller { }

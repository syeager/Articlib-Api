using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Articlib.Core.Api.Articles;

[Route("articles", Name = "Articles")]
[OpenApiTag("Articles")]
[ApiController]
public abstract class ArticleController : Controller { }

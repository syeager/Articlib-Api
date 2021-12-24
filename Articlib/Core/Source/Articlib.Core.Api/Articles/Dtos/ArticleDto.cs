﻿using System.ComponentModel.DataAnnotations;
using LittleByte.Extensions.AspNet.Core;

namespace Articlib.Core.Api.Articles;

public class ArticleDto : Dto
{
    [Required]
    [Url]
    public string Url { get; init; } = null!;
    [Required]
    public Guid PosterId { get; init; }
}

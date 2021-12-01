﻿using System.Diagnostics.CodeAnalysis;
using LittleByte.Logging;

namespace Articlib.Core.Domain.Articles;

[ExcludeFromCodeCoverage]
public static partial class LK
{
    public static class Article
    {
        private const string A = nameof(Article);
        public static readonly string Id = Keys.New(A, nameof(Id));
        public static readonly string Url = Keys.New(A, nameof(Url));
        public static readonly string PosterId = Keys.New(A, nameof(PosterId));
    }
}
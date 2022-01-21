using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Articles.Domain.Votes.Models;

public sealed record Vote(Id<Article> ArticleId, Id<User> UserId, DateTime VotedDate);

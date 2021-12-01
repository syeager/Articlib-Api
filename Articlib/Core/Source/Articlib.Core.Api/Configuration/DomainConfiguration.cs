using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using LittleByte.Validation;

namespace Articlib.Core.Api.Configuration
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection @this)
        {
            return @this
                // TODO: Separate these into their own domains.
                .AddTransient<IModelValidator<Article>, ArticleValidator>()
                .AddTransient<IArticleCreateService, ArticleCreateService>()
                .AddTransient<IUserRegisterService, UserRegisterService>();
        }
    }
}
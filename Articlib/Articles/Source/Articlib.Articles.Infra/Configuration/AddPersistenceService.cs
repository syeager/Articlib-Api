using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Articles.Infra
{
    public static class AddPersistenceService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services
                .AddDbContext<ArticleDb>(builder => builder.UseInMemoryDatabase("articles"));
        }
    }
}

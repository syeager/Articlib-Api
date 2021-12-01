using Articlib.Articles.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Articlib.Articles.Data
{
    public class ArticleDbFactory : IDesignTimeDbContextFactory<ArticleDb>
    {
        ArticleDb IDesignTimeDbContextFactory<ArticleDb>.CreateDbContext(string[] args)
        {
            Console.WriteLine("Using Factory");
            var connectionString = "Server=database;Database=Articlib;Uid=dev;Pwd=pass;";

            var optionsBuilder = new DbContextOptionsBuilder<ArticleDb>();
            optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);

            return new ArticleDb(optionsBuilder.Options);
        }
    }
}

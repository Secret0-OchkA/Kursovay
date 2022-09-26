using Kursovay.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class PostgresContextFactory : IDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = configurationBuilder.Build();

            string connectionStr = config.GetConnectionString("Postgres");

            DbContextOptionsBuilder<ApiContext> optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseNpgsql(connectionStr);

            return new ApiContext(optionsBuilder.Options);
        }
    }
}

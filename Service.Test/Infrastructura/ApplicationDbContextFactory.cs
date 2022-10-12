using Api.Test.Infrastructura;
using Context;

namespace Service.Test.Infrastructura
{
    internal class ApplicationDbContextFactory
    {
        public ApplicationDbContextTest CreateDbContext(string databaseName)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase(databaseName);

            ApplicationDbContextTest dbContext = new ApplicationDbContextTest(optionsBuilder.Options);
            Initialize(dbContext);
            return dbContext;
        }

        public static void Initialize(ApplicationDbContextTest dbContext)
        {

            dbContext.SaveChanges();
        }
    }
}

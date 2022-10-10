using Api.Test.Infrastructura;
using Context;

namespace Service.Test.Infrastructura
{
    internal class ApplicationDbContextFactory
    {
        public ApplicationDbContextTest CreateDbContext(string databaseName)
        {
            DbContextOptionsBuilder<ApplicationDbContextTest> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContextTest>();
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

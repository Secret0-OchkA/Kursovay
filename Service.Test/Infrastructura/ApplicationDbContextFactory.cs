namespace Service.Test.Infrastructura
{
    internal class ApplicationDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string databaseName)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase(databaseName);

            ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);
            Initialize(dbContext);
            return dbContext;
        }

        public static void Initialize(ApplicationDbContext dbContext)
        {

            dbContext.SaveChanges();
        }
    }
}

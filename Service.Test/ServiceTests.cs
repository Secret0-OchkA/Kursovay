using Context;

namespace Service.Test
{
    internal class ServiceTests
    {
        ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("CompanyService");
        }

        [Test]
        public void Should_CreateCompany()
        {
        }
    }
}

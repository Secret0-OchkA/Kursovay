using Api.Test.Infrastructura;
using Context;
using DockerTestBD.Api.Controllers;
using Domain.Model;

namespace Service.Test
{
    internal class CompanyControllerTests
    {
        ApplicationDbContextTest dbContext;
        CompanyController controller;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("CompanyService");
            controller = new CompanyController(dbContext);
        }

        [Test]
        public void When_MinInfo_Should_CreateCompany()
        {
        }
    }
}

using Domain.Model;
using Repository.RepositoryPattern;

namespace Service.Test
{
    internal class ServiceTests
    {
        ApplicationDbContext dbContext;
        IService<Company> service;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("CompanyService");
            this.service = new Service<Company>(new Repository<Company>(dbContext));
        }

        [Test]
        public void Should_CreateCompany()
        {
            string name = "testCreateCompany";
            Company company = new Company { Name = name };

            service.Create(company);

            Company dbCompany = dbContext.companies.Where(c => c.Name == name).Single();

            JsonCompare.Compare(new { Name = company.Name }, new { Name = dbCompany.Name });
        }
    }
}

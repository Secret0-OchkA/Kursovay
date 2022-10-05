using Domain.Model;
using Repository.RepositoryPattern;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    internal class CompanyServiceTest
    {
        ApplicationDbContext dbContext;
        CompanyService service;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("CompanyService");
            service = new CompanyService(new Repository<Department>(dbContext));
        }

        [Test]
        public void Should_CreateCompany()
        {
            string name = "testCreateCompany";
            Department company = new Department { Name = name };
            //service.CreateCompany(company);

            Department dbCompany = dbContext.companies.Where(c => c.Name == name).Single();

            JsonCompare.Compare(new {Name = company.Name}, new {Name = dbCompany.Name});
        }
        [Test]
        public void Should_DeletCompany()
        {
            string name = "delet";
            dbContext.Add(new Department { Name = name });
            dbContext.SaveChanges();
            Department company = dbContext.companies.Where(c => c.Name == name).Single();

            //service.DeleteCompany(company.Id);

            Assert.Throws<InvalidOperationException>(()=>dbContext.companies.Where(c => c.Name == name).Single());
        }

        [Test]
        public void When_NewDepartment_Should_Add()
        {
            //Company company = service.GetEntity(1);
        }

    }
}

using Api.Test.Infrastructura;
using DockerTestBD.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test
{
    class DepartmentControllerTest
    {
        ApplicationDbContextTest dbContext;
        DepartmentController controller;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("Database");
            controller = new DepartmentController(dbContext);
        }

        [Test]
        public void DeletById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Delete(-1,1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void DeletById_Should_BadRequest_When_NotExistDepartment()
        {
            var result = controller.Delete(1, -1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void GetById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Get(-1, 1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void GetById_Should_BadRequest_When_NotExistDepartment()
        {
            var result = controller.Get(1, -1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void SetBudget_Should_BadRequest_When_NotExistDepartment()
        {
            var result = controller.SetBuget(-1, 100);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void SetBudget_Should_BadRequest_When_BudgetLessZero()
        {
            var result = controller.SetBuget(1, -100);
            Assert.That(result, Is.Not.Null);
            Assert.That(result is BadRequestObjectResult);
        }
    }
}

﻿using Api.Test.Infrastructura;
using Context;
using DockerTestBD.Api.Controllers;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Service.Test
{
    internal class CompanyControllerTests
    {
        ApplicationDbContextTest dbContext;
        CompanyController controller;
        [SetUp]
        public void Setup()
        {
            this.dbContext = new ApplicationDbContextFactory().CreateDbContext("Database");
            controller = new CompanyController(dbContext);
        }

        [Test]
        public void GetById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Get(-1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void DeleteById_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.Delete(-1);
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
        [Test]
        public void ChangeName_Should_BadRequest_When_NotExistCompany()
        {
            var result = controller.ChangeName(-1, "newName");
            Assert.IsNotNull(result);
            Assert.That(result is BadRequestObjectResult);
        }
    }
}

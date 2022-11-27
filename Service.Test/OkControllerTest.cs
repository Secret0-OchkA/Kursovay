using Api.Test.Infrastructura;
using DockerTestBD.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test
{
    class OkControllerTest
    {
        OkController controller;
        [SetUp]
        public void Setup()
        {
            controller = new OkController();
        }

        [Test]
        public void Should_ReturnOk_When_GetRequest()
        {
            var result = controller.OK();
            Assert.IsNotNull(result);
            Assert.That(result is OkResult);
        }
    }
}

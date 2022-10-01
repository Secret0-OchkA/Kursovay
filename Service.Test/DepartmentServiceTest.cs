using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    internal class DepartmentServiceTest
    {
        ApplicationDbContext dbContext;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("DepartmentService");
        }
    }
}

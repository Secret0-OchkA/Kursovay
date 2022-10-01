using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    internal class AccountServiceTest
    {
        ApplicationDbContext dbContext;
        [SetUp]
        public void Setup()
        {
            dbContext = new ApplicationDbContextFactory().CreateDbContext("AccountService");
        }
    }
}

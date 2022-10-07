using Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test.Infrastructura
{
    internal class ApplicationDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string databaseName)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName);

            ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);
            Initialize(dbContext);
            return dbContext;
        }

        public static void Initialize(ApplicationDbContext dbContext)
        {
        }
    }
}

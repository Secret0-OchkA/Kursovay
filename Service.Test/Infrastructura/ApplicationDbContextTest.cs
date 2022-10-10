using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Infrastructura
{
    class ApplicationDbContextTest : ApplicationDbContext
    {
        public ApplicationDbContextTest(DbContextOptions<ApplicationDbContextTest> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

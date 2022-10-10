﻿using Context;
using Microsoft.EntityFrameworkCore;

namespace DockerTestBD.Api
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = configurationBuilder.Build();

            string connectionStr = config.GetConnectionString("Postgres");

            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(connectionStr);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

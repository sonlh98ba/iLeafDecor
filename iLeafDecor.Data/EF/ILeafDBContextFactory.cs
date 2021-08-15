using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iLeafDecor.Data.EF
{
    class ILeafDBContextFactory : IDesignTimeDbContextFactory<ILeafDBContext>
    {
        public ILeafDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("iLeafDecorDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<ILeafDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ILeafDBContext(optionsBuilder.Options);
        }
    }
}

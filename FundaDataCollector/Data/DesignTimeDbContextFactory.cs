using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FundaDataCollector.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        
        optionsBuilder.UseSqlServer(connectionString!);

        return new MyDbContext(optionsBuilder.Options);
    }
}
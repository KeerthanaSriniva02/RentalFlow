using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RentalFlow.Infrastructure.Data;

namespace RentalFlow.Infrastructure;

public class RentalDbContextFactory
    : IDesignTimeDbContextFactory<RentalDbContext>
{
    public RentalDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder =
            new DbContextOptionsBuilder<RentalDbContext>();

        var connectionString =
            configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlite(connectionString);

        return new RentalDbContext(optionsBuilder.Options);
    }
}
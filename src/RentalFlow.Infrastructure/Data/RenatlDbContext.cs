using Microsoft.EntityFrameworkCore;
using RentalFlow.Domain.Entities;

namespace RentalFlow.Infrastructure.Data;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions<RentalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties => Set<Property>();
}
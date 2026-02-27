using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalFlow.Domain.Interfaces;
using RentalFlow.Infrastructure.Data;
using RentalFlow.Infrastructure.Repositories;

namespace RentalFlow.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<RentalDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPropertyRepository, PropertyRepository>();

        return services;
    }
}
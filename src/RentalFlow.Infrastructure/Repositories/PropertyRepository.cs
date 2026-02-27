using Microsoft.EntityFrameworkCore;
using RentalFlow.Domain.Entities;
using RentalFlow.Domain.Interfaces;
using RentalFlow.Infrastructure.Data;

namespace RentalFlow.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly RentalDbContext _context;

    public PropertyRepository(RentalDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
        => await _context.Properties.ToListAsync();

    public async Task<Property?> GetByIdAsync(Guid id)
        => await _context.Properties.FindAsync(id);

    public async Task AddAsync(Property property)
    {
        await _context.Properties.AddAsync(property);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var property = await _context.Properties.FindAsync(id);

        if (property != null)
        {
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
        }
    }
}
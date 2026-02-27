using RentalFlow.Domain.Entities;

namespace RentalFlow.Domain.Interfaces;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetAllAsync();

    Task<Property?> GetByIdAsync(Guid id);

    Task AddAsync(Property property);

    Task UpdateAsync(Property property);

    Task DeleteAsync(Guid id);
}
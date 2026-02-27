using RentalFlow.Application.DTOs;

namespace RentalFlow.Application.Interfaces;

public interface IPropertyService
{
    Task<IEnumerable<PropertyDto>> GetAllAsync();

    Task<PropertyDto?> GetByIdAsync(Guid id);

    Task<Guid> CreateAsync(CreatePropertyDto dto);

    Task UpdateAsync(Guid id, CreatePropertyDto dto);

    Task DeleteAsync(Guid id);
}
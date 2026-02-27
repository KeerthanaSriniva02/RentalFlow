using RentalFlow.Application.DTOs;
using RentalFlow.Application.Interfaces;
using RentalFlow.Domain.Entities;
using RentalFlow.Domain.Interfaces;

namespace RentalFlow.Application.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _repository;

    public PropertyService(IPropertyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PropertyDto>> GetAllAsync()
    {
        var properties = await _repository.GetAllAsync();

        return properties.Select(p => new PropertyDto
        {
            Id = p.Id,
            Name = p.Name,
            Address = p.Address,
            RentAmount = p.RentAmount,
            IsAvailable = p.IsAvailable
        });
    }

    public async Task<PropertyDto?> GetByIdAsync(Guid id)
    {
        var property = await _repository.GetByIdAsync(id);

        if (property == null)
            return null;

        return new PropertyDto
        {
            Id = property.Id,
            Name = property.Name,
            Address = property.Address,
            RentAmount = property.RentAmount,
            IsAvailable = property.IsAvailable
        };
    }

    public async Task<Guid> CreateAsync(CreatePropertyDto dto)
    {
        var property = new Property
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            RentAmount = dto.RentAmount,
            IsAvailable = true
        };

        await _repository.AddAsync(property);

        return property.Id;
    }

    public async Task UpdateAsync(Guid id, CreatePropertyDto dto)
    {
        var property = await _repository.GetByIdAsync(id);

        if (property == null)
            throw new Exception("Property not found");

        property.Name = dto.Name;
        property.Address = dto.Address;
        property.RentAmount = dto.RentAmount;

        await _repository.UpdateAsync(property);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
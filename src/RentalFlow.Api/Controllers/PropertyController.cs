using Microsoft.AspNetCore.Mvc;
using RentalFlow.Application.DTOs;
using RentalFlow.Application.Interfaces;

namespace RentalFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var properties = await _propertyService.GetAllAsync();
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var property = await _propertyService.GetByIdAsync(id);

        if (property == null)
            return NotFound();

        return Ok(property);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePropertyDto dto)
    {
        var id = await _propertyService.CreateAsync(dto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, CreatePropertyDto dto)
    {
        await _propertyService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _propertyService.DeleteAsync(id);
        return NoContent();
    }
}
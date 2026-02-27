namespace RentalFlow.Application.DTOs;

public class PropertyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public decimal RentAmount { get; set; }

    public bool IsAvailable { get; set; }
}
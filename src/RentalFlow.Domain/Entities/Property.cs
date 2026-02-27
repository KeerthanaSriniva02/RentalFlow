namespace RentalFlow.Domain.Entities;

public class Property
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public decimal RentAmount { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
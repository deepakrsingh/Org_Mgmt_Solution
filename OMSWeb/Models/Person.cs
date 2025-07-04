#nullable enable

namespace OMSWeb.Modelsl;

public class Person
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Occuptation { get; set; }
    public required DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

using Domain.Primitives;

namespace Domain.Entities;

public sealed class Person : Entity
{
    public DateTime DateOfBirth { get; set; }
    public string? Name { get; set; }
    public string? SocialNumber { get; set; }
}
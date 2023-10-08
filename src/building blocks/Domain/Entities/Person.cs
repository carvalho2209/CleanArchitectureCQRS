using Domain.Primitives;

namespace Domain.Entities;

public sealed class Person : Entity
{
    public Person(Guid id, DateTime dateOfBirth, string? name, string? socialNumber)
        : base(id)
    {
        DateOfBirth = dateOfBirth;
        Name = name;
        SocialNumber = socialNumber;
    }

    private Person() { }

    public DateTime DateOfBirth { get; set; }
    public string? Name { get; set; }
    public string? SocialNumber { get; private set; }
}
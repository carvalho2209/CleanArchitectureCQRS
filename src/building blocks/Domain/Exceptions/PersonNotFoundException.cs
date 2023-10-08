namespace Domain.Exceptions;

public sealed class PersonNotFoundException(Guid personId) 
    : DirectoryNotFoundException($"The Person with the identifier {personId} was not found.")
{
}
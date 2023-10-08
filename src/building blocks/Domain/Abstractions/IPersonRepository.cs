using Domain.Entities;

namespace Domain.Abstractions;

public interface IPersonRepository
{
    void Insert(Person  person);
}

using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories;

public sealed class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context) => _context = context;

    public void Insert(Person person) => _context.Set<Person>().Add(person);
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    DbSet<Person> Persons { get; } 

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Persons.Queries;

public sealed class PersonQuery : IRequest<PersonVm[]>
{
    public sealed class Handler(IUnitOfWork unitOfWork) : IRequestHandler<PersonQuery, PersonVm[]>
    {
        public Task<PersonVm[]> Handle(PersonQuery request, CancellationToken cancellationToken) => unitOfWork
            .Persons
            .Select(x => new PersonVm(x.Id, x.DateOfBirth, x.Name!, x.SocialNumber!))
            .ToArrayAsync(cancellationToken);
    }
}
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands;

public sealed class CreatePersonCommand(Guid? id, DateTime dateOfBirth, string name, string socialNumber) : IRequest<Guid>
{
    public Guid? Id { get; } = id;
    public DateTime DateOfBirth { get; } = dateOfBirth;
    public string Name { get; } = name;
    public string SocialNumber { get; } = socialNumber;

    public class Handler(IUnitOfWork unitOfWork, IPersonRepository personRepository) : IRequestHandler<CreatePersonCommand, Guid>
    {
        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(Guid.NewGuid(), request.DateOfBirth, request.Name, request.SocialNumber);

             personRepository.Insert(person);
             await unitOfWork.SaveChangesAsync(cancellationToken);
             
             return person.Id;
        }
    }
}

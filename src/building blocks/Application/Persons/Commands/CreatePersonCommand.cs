using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Persons.Commands;

public sealed class CreatePersonCommand(Guid? id, DateTime dateOfBirth, string name, string socialNumber) : IRequest<Guid>
{
    public Guid? Id { get; } = id;
    public DateTime DateOfBirth { get; } = dateOfBirth;
    public string Name { get; } = name;
    public string SocialNumber { get; } = socialNumber;

    public class Handler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            if (request.Id.HasValue && await _unitOfWork.Persons.AnyAsync(x=>x.Id == request.Id.Value, cancellationToken))
            {
                throw new ArgumentException($"The Person with Id {request.Id} already exists.");
            }

            var person = new Person
            {
                Id = request.Id.GetValueOrDefault(Guid.NewGuid()),
                Name = request.Name,
                SocialNumber = request.SocialNumber,
                DateOfBirth = request.DateOfBirth,
            };

            await unitOfWork.Persons.AddAsync(person, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}

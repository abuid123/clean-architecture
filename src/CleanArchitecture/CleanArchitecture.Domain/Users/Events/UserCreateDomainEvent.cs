using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid Id) : IDomainEvent
{

}
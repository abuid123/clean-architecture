using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Reviews.Events
{
  public sealed record ReviewCreatedDomainEvent(Guid AlquilerId) : IDomainEvent;
}
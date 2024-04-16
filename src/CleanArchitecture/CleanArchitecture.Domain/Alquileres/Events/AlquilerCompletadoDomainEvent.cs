using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Alquileres.Events
{
  public sealed record AlquilerCompletadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
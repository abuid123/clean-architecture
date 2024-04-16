using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Alquileres.Events
{
  public sealed record AlquilerRechazadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
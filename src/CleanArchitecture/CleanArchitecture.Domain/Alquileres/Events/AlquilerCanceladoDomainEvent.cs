using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Alquileres.Events
{
  public sealed record AlquilerCanceladoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
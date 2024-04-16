using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Alquileres.Events
{
  public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
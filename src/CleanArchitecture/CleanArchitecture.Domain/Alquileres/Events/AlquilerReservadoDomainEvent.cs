using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Alquileres.Events;
public sealed record AlquilerReservadoDomainEvent(Guid AlquilerId) : IDomainEvent
{
}

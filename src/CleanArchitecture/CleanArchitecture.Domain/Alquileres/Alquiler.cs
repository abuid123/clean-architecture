using CleanArchitecture.Domain.Abstactions;
using CleanArchitecture.Domain.Alquileres.Events;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres;

public sealed class Alquiler : Entity
{
  private Alquiler(Guid id, Guid vehiculoId, Guid userId, Moneda? precioPorPeriodo, Moneda? mantenimiento, Moneda? accesorios, Moneda? precioTotal, DateTime? fechaCreacion, AlquilerStatus status, DateRange duracion) : base(id)
  {
    Id = id;
    VehiculoId = vehiculoId;
    UserId = userId;
    PrecioPorPeriodo = precioPorPeriodo;
    Mantenimiento = mantenimiento;
    Accesorios = accesorios;
    PrecioTotal = precioTotal;
    FechaCreacion = fechaCreacion;
    Status = status;
    DuracionAlquiler = duracion;
  }

  public Guid VehiculoId { get; private set; }
  public Guid UserId { get; private set; }
  public Moneda? PrecioPorPeriodo { get; private set; }
  public Moneda? Mantenimiento { get; private set; }
  public Moneda? Accesorios { get; private set; }
  public Moneda? PrecioTotal { get; private set; }
  public DateTime? FechaCreacion { get; private set; }
  public DateTime? FechaConfirmacion { get; private set; }
  public DateTime? FechaCancelacion { get; private set; }
  public DateRange? DuracionAlquiler { get; private set; }
  public AlquilerStatus Status { get; private set; }

  public static Alquiler Reservar(
    Guid vehiculoId,
    Guid userId,
    DateRange duracionAlquiler,
    DateTime fechaCreacion,
    PrecioDetalle precioDetalle
  )
  {
    var alquiler = new Alquiler(
      Guid.NewGuid(),
      vehiculoId,
      userId,
      precioDetalle.PrecioPorPeriodo,
      precioDetalle.Mantenimiento,
      precioDetalle.Accesorios,
      precioDetalle.PrecioTotal,
      fechaCreacion,
      AlquilerStatus.Reservado,
      duracionAlquiler
    );

    alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id!));

    return alquiler;
  }
}
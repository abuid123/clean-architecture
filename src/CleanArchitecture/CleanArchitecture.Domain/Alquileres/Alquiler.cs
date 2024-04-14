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
  public DateTime? FechaRechazado { get; private set; }
  public DateTime? FechaCompletado { get; private set; }
  public DateRange? DuracionAlquiler { get; private set; }
  public AlquilerStatus Status { get; private set; }

  public static Alquiler Reservar(
    Vehiculo vehiculo,
    Guid userId,
    DateRange duracionAlquiler,
    DateTime fechaCreacion
  )
  {
    var precioDetalle = PrecioService.CalcularPrecio(
      vehiculo,
      duracionAlquiler
    );

    var alquiler = new Alquiler(
      Guid.NewGuid(),
      vehiculo.Id,
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

    vehiculo.FechaUltimaAlquiler = fechaCreacion;

    return alquiler;
  }

  public Result Confirmar(DateTime utcNow)
  {
    if (Status is not AlquilerStatus.Reservado)
    {
      return Result.Failure(AlquilerErrors.NotReserved);
    }

    Status = AlquilerStatus.Confirmado;
    FechaConfirmacion = utcNow;

    RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id));
    return Result.Success();
  }

  public Result Rechazar(DateTime utcNow)
  {
    if (Status is not AlquilerStatus.Reservado)
    {
      return Result.Failure(AlquilerErrors.NotReserved);
    }

    Status = AlquilerStatus.Rechazado;
    FechaRechazado = utcNow;

    RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id));
    return Result.Success();
  }

  public Result Cancelar(DateTime utcNow)
  {
    if (Status is not AlquilerStatus.Confirmado)
    {
      return Result.Failure(AlquilerErrors.NotConfirmed);
    }

    var currentDate = DateOnly.FromDateTime(utcNow);

    if (DuracionAlquiler!.Start <= currentDate)
    {
      return Result.Failure(AlquilerErrors.AlreadyStarted);
    }

    Status = AlquilerStatus.Cancelado;
    FechaCancelacion = utcNow;

    RaiseDomainEvent(new AlquilerCanceladoDomainEvent(Id));
    return Result.Success();
  }
}
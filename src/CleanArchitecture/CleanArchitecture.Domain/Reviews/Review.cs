using CleanArchitecture.Domain.Abstactions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Reviews.Events;

namespace CleanArchitecture.Domain.Reviews;

public sealed class Review : Entity
{
  private Review(Guid id, Guid vehiculoId, Guid userId, Guid alquilerId, Rating rating, Comentario? comentario, DateTime? fechaCreacion) : base(id)
  {
    Id = id;
    VehiculoId = vehiculoId;
    UserId = userId;
    AlquilerId = alquilerId;
    Rating = rating;
    Comentario = comentario;
    FechaCreacion = fechaCreacion;
  }

  public Guid VehiculoId { get; private set; }
  public Guid UserId { get; private set; }
  public Guid AlquilerId { get; private set; }
  public Rating Rating { get; private set; }
  public Comentario? Comentario { get; private set; }
  public DateTime? FechaCreacion { get; private set; }

  public static Result<Review> Create(Alquiler alquiler, Rating rating, Comentario comentario, DateTime fechaCreacion)
  {
    if (alquiler.Status is not AlquilerStatus.Completado)
    {
      return Result.Failure<Review>(ReviewErrors.NotEligible);
    }

    var review = new Review(
      Guid.NewGuid(),
      alquiler.VehiculoId,
      alquiler.UserId,
      alquiler.Id,
      rating,
      comentario,
      fechaCreacion
    );

    review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id!));

    return review;
  }
}
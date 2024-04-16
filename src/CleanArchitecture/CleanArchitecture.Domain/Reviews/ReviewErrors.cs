using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Reviews;

public static class ReviewErrors
{
  public static readonly Error NotEligible = new("Review.NotEligible", "Esta review y calificacion para el auto no es elegible porque aun no se completa el alquiler.");
}
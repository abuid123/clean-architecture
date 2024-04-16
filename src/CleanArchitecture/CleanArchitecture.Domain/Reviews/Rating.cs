using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Reviews
{
  public sealed record Rating
  {
    public static readonly Error InvalidRating = new("Rating.InvalidRating", "La calificacion debe estar entre 1 y 5.");

    public int Value { get; init; }

    private Rating(int value)
    {
      Value = value;
    }

    public static Result<Rating> Create(int value)
    {
      if (value < 1 || value > 5)
      {
        return Result.Failure<Rating>(InvalidRating);
      }

      return new Rating(value);
    }
  }
}
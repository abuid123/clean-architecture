namespace CleanArchitecture.Domain.Alquileres;

public sealed record DateRange
{
  private DateRange(DateOnly start, DateOnly end)
  {
    Start = start;
    End = end;
  }

  public DateOnly Start { get; init; }
  public DateOnly End { get; init; }
  public int Days => End.DayNumber - Start.DayNumber;

  public static DateRange Create(DateOnly start, DateOnly end)
  {
    if (start > end)
    {
      throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha de fin");
    }

    return new DateRange(start, end);
  }
}
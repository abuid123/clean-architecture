using CleanArchitecture.Application.Abstractions.Clock;

namespace CleanArchitecture.Infraestructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}

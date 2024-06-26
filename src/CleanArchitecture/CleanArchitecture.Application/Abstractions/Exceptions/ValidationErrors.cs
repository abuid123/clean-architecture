namespace CleanArchitecture.Application.Abstractions.Exceptions;

public sealed record ValidationErrors(string PropertyName, string Message);

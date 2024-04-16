using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace CleanArchitecture.Domain.Abstactions;

public class Result
{
  protected internal Result(bool isSuccess, Error? error)
  {
    if (isSuccess && error != Error.None)
    {
      throw new InvalidOperationException();
    }

    if (!isSuccess && error == Error.None)
    {
      throw new InvalidOperationException();
    }

    IsSuccess = isSuccess;
    Error = error;
  }
  public bool IsSuccess { get; }
  public bool IsFailure => !IsSuccess;
  public Error? Error { get; }
  public static Result Success() => new(true, Error.None);
  public static Result Failure(Error error) => new(false, error);
  public static Result<TValue> Success<TValue>(TValue value) => new(true, value, Error.None);
  public static Result<TValue> Failure<TValue>(Error error) => new(false, default, error);
  public static Result<TValue> Create<TValue>(TValue value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
  public readonly TValue? _value;

  protected internal Result(bool isSuccess, TValue? value, Error? error) : base(isSuccess, error)
  {
    _value = value;
  }

  [NotNull]
  public TValue Value => IsSuccess
    ? _value!
    : throw new InvalidOperationException("El resultado del valor de error no es admisible.");

  public static implicit operator Result<TValue>(TValue value) => Create(value);
}
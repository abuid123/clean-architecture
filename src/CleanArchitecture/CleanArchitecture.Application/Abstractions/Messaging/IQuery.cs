using CleanArchitecture.Domain.Abstactions;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}

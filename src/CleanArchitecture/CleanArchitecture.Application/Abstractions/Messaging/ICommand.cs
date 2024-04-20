using CleanArchitecture.Domain.Abstactions;
using MediatR;

namespace CleanArchitecture.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

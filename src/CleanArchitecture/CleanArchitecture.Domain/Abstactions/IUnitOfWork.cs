namespace CleanArchitecture.Domain.Abstactions;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
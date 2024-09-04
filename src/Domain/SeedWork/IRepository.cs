using System.Linq.Expressions;
using Infrastructure.Caching;

namespace Domain.SeedWork;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}

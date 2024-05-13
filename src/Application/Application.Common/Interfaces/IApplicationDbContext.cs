using Domain.Common;
using Domain.Entities;
using Domain.Entities.Catalog;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext: IUnitOfWork
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Product> Products { get; }


}

using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
<<<<<<< HEAD
using Toss.Inventory.Application.Common.Interfaces;
using Toss.Inventory.Application.Common.Models;
using Toss.Inventory.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Toss.Inventory.Application.TodoLists.Queries.GetTodos;
using Toss.Inventory.Domain.Entities;
using NUnit.Framework;

namespace Toss.Inventory.Application.UnitTests.Common.Mappings;
=======
using NUnit.Framework;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Todo.TodoItems.Queries.GetTodoItemsWithPagination;
using Application.Todo.TodoLists.Queries.GetTodos;
using Domain.Entities;

namespace Toss.Inventory.Catalog.Application.UnitTests.Common.Mappings;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(TodoList), typeof(TodoListDto))]
    [TestCase(typeof(TodoItem), typeof(TodoItemDto))]
    [TestCase(typeof(TodoList), typeof(LookupDto))]
    [TestCase(typeof(TodoItem), typeof(LookupDto))]
    [TestCase(typeof(TodoItem), typeof(TodoItemBriefDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return RuntimeHelpers.GetUninitializedObject(type);
    }
}

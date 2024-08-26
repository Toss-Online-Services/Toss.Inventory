using System.Reflection;

<<<<<<< HEAD
namespace Toss.Inventory.Web.Infrastructure;
=======
namespace Toss.Inventory.Catalog.Web.Infrastructure;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public static class MethodInfoExtensions
{
    public static bool IsAnonymous(this MethodInfo method)
    {
        var invalidChars = new[] { '<', '>' };
        return method.Name.Any(invalidChars.Contains);
    }

    public static void AnonymousMethod(this IGuardClause guardClause, Delegate input)
    {
        if (input.Method.IsAnonymous())
            throw new ArgumentException("The endpoint name must be specified when using anonymous handlers.");
    }
}
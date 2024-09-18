
namespace Web.Framework.Factories
{
    public interface IWidgetPluginManager
    {
        Task<IEnumerable<object>> LoadActivePluginsAsync(Customer customer, int id, string widgetZone);
    }
}
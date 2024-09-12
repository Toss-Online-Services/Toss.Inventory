using Infrastructure.Configuration;
using Domain.Infrastructure;
using Infrastructure.DataProviders;

namespace Infrastructure;

/// <summary>
/// Represents the data provider manager
/// </summary>
public partial class DataProviderManager : IDataProviderManager
{
    #region Methods

    /// <summary>
    /// Gets data provider by specific type
    /// </summary>
    /// <param name="dataProviderType">Data provider type</param>
    /// <returns></returns>
    public static INopDataProvider GetDataProvider(DataProviderType dataProviderType)
    {
        return dataProviderType switch
        {
            DataProviderType.SqlServer => new MsSqlNopDataProvider(),
            DataProviderType.MySql => new MySqlNopDataProvider(),
            DataProviderType.PostgreSQL => new PostgreSqlDataProvider(),
            _ => throw new DomainException($"Not supported data provider name: '{dataProviderType}'"),
        };
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets data provider
    /// </summary>
    public INopDataProvider DataProvider
    {
        get
        {
            var dataProviderType = Singleton<DataConfig>.Instance.DataProvider;

            return GetDataProvider(dataProviderType);
        }
    }

    #endregion
}

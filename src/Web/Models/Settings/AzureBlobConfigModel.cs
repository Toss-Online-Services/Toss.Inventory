namespace Web.Models.Settings;

/// <summary>
/// Represents Azure Blob storage configuration model
/// </summary>
public partial record AzureBlobConfigModel : BaseNopModel, IConfigModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.ConnectionString")]
    public string ConnectionString { get; set; } = string.Empty;

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.ContainerName")]
    public string ContainerName { get; set; } = string.Empty;

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.EndPoint")]
    public string EndPoint { get; set; } = string.Empty;

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.AppendContainerName")]
    public bool AppendContainerName { get; set; }

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.StoreDataProtectionKeys")]
    public bool StoreDataProtectionKeys { get; set; }

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysContainerName")]
    public string DataProtectionKeysContainerName { get; set; } = string.Empty;

    [NopResourceDisplayName("Admin.Configuration.AppSettings.AzureBlob.DataProtectionKeysVaultId")]
    public string DataProtectionKeysVaultId { get; set; } = string.Empty;

    #endregion
}

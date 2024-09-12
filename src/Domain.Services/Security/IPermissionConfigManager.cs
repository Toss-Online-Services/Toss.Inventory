﻿namespace Domain.Services.Security;

/// <summary>
/// Represents a permission config manager
/// </summary>
public partial interface IPermissionConfigManager
{
    /// <summary>
    /// Gets all permission configurations
    /// </summary>
    IList<PermissionConfig> AllConfigs { get; }
}
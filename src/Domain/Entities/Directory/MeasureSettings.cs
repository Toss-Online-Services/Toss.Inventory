﻿using Domain.Entities.Configuration;

namespace Domain.Entities.Directory;

/// <summary>
/// Measure settings
/// </summary>
public partial class MeasureSettings : ISettings
{
    /// <summary>
    /// Base dimension identifier
    /// </summary>
    public int BaseDimensionId { get; set; }

    /// <summary>
    /// Base weight identifier
    /// </summary>
    public int BaseWeightId { get; set; }
}
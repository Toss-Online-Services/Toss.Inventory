using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure;
/// <summary>
/// Represents an entity which supports store mapping
/// </summary>
public partial interface IStoreMappingSupported
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    bool LimitedToStores { get;}
}

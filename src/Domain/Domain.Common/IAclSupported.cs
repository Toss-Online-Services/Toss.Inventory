using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure;
/// <summary>
/// Represents an entity which supports ACL
/// </summary>
public interface IAclSupported
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to ACL
    /// </summary>
    bool SubjectToAcl { get;}
}

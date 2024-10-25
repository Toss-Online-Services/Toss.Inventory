using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a measure weight list model
/// </summary>
public partial record MeasureWeightListModel : BasePagedListModel<MeasureWeightModel>
{
}
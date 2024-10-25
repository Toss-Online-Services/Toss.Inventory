using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a measure dimension list model
/// </summary>
public partial record MeasureDimensionListModel : BasePagedListModel<MeasureDimensionModel>
{
}
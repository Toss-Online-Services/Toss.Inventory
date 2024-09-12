using ClosedXML.Excel;
using Domain.Services.ExportImport.Help;

namespace Domain.Services.ExportImport;

public partial class WorkbookMetadata<T>
{
    public List<PropertyByName<T, Language>> DefaultProperties { get; set; }

    public List<PropertyByName<T, Language>> LocalizedProperties { get; set; }

    public IXLWorksheet DefaultWorksheet { get; set; }

    public List<IXLWorksheet> LocalizedWorksheets { get; set; }
}
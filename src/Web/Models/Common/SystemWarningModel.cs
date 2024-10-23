namespace Web.Models.Common;

public partial record SystemWarningModel : BaseNopModel
{
    public SystemWarningLevel Level { get; set; }

    public string Text { get; set; }

    public bool DontEncode { get; set; }

    public override string ToString()
    {
        return Text;
    }
}